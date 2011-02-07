using System;
using System.Collections;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using NHibernate;

namespace MavenThought.MediaLibrary.Storage.NHibernate
{
    /// <summary>
    /// Storage helper provides extensions to save, update, auto commit and auto session
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// Lists all the elements of type T in the storage
        /// </summary>
        /// <typeparam name="T">Type of the element to look for</typeparam>
        /// <param name="factory">Factory to open the session</param>
        /// <returns>A collection with all the elements</returns>
        public static IList<T> List<T>(this ISessionFactory factory)
        {
            return factory
                .AutoSession(s => s
                                      .CreateCriteria(typeof(T))
                                      .List<T>());
        }

        /// <summary>
        /// Saves or updates the object using AutoCommit
        /// </summary>
        /// <param name="storage">Storage to use</param>
        /// <param name="target">Target to save</param>
        public static void SaveOrUpdate(this ISessionFactory storage, object target)
        {
            storage.AutoCommit(s => s.SaveOrUpdate(target));
        }

        /// <summary>
        /// Saves or updates all the items in the collection using auto commit
        /// </summary>
        /// <param name="storage">Storage to use</param>
        /// <param name="items">Items to store</param>
        public static void SaveCollection(this ISessionFactory storage, IEnumerable items)
        {
            storage.AutoCommit(s => items.ForEach<object>(s.SaveOrUpdate));
        }

        /// <summary>
        /// Deletes all the items in the collection
        /// </summary>
        /// <param name="storage">Storage to use</param>
        /// <param name="items">Items to delete</param>
        public static void DeleteCollection(this ISessionFactory storage, IEnumerable items)
        {
            storage.AutoCommit(s => items.ForEach<object>(s.Delete));
        }

        /// <summary>
        /// Deletes the item specified
        /// </summary>
        /// <param name="storage">Storage to use</param>
        /// <param name="target">Instance to delete</param>
        public static void Delete(this ISessionFactory storage, object target)
        {
            storage.AutoCommit(s => s.Delete(target));
        }

        /// <summary>
        /// Opens a session and runs the action within it
        /// </summary>
        /// <param name="storage">Storage to open the session</param>
        /// <param name="action">Action to call with the session</param>
        public static void AutoSession(this ISessionFactory storage, Action<ISession> action)
        {
            using (var session = storage.OpenSession())
            {
                action(session);
            }
        }

        /// <summary>
        /// Opens a session, runs the action and returns the result
        /// </summary>
        /// <typeparam name="T">Type of the result</typeparam>
        /// <param name="storage">Storage to use</param>
        /// <param name="action">Action to use</param>
        /// <returns>The result of calling the action with the session</returns>
        public static T AutoSession<T>(this ISessionFactory storage, Func<ISession, T> action)
        {
            var result = default(T);

            AutoSession(storage, s => { result = action(s); });

            return result;
        }

        /// <summary>
        /// Runs an action inside a transaction
        /// </summary>
        /// <param name="storage">Storage to use</param>
        /// <param name="action">Action to call</param>
        public static void AutoCommit(this ISessionFactory storage, Action<ISession> action)
        {
            storage.AutoSession(s =>
                                    {
                                        using (var tx = s.BeginTransaction())
                                        {
                                            try
                                            {
                                                action(s);

                                                tx.Commit();
                                            }
                                            catch
                                            {
                                                tx.Rollback();
                                                throw;
                                            }
                                        }
                                    });
        }

        /// <summary>
        /// Runs a functor inside a transaction
        /// </summary>
        /// <typeparam name="TResult">Type of the result of the functor</typeparam>
        /// <param name="storage">Storage to use</param>
        /// <param name="functor">Functor to call</param>
        /// <returns>Result of the functor</returns>
        public static TResult AutoCommit<TResult>(this ISessionFactory storage,
                                                  Func<ISession, TResult> functor)
        {
            var result = default(TResult);

            storage.AutoSession(s =>
                                    {
                                        using (var tx = s.BeginTransaction())
                                        {
                                            try
                                            {
                                                result = functor(s);

                                                tx.Commit();
                                            }
                                            catch
                                            {
                                                tx.Rollback();

                                                throw;
                                            }
                                        }
                                    });

            return result;
        }
    }
}