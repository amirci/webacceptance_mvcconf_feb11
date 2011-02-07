using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MavenThought.MediaLibrary.Core;
using NHibernate;
using NHibernate.Cfg;

namespace MavenThought.MediaLibrary.Storage.NHibernate
{
    /// <summary>
    /// Gateway to create session factory
    /// </summary>
    public class SessionFactoryGateway
    {
        /// <summary>
        /// Creates a session factory using the configurer and the action
        /// </summary>
        /// <param name="configurer">Configuration for persistence to use</param>
        /// <param name="buildSchema">Optional schema generation</param>
        /// <returns></returns>
        public static ISessionFactory CreateSessionFactory(IPersistenceConfigurer configurer,
                                                           Action<Configuration> buildSchema)
        {
            return Fluently
                .Configure()
                .ExposeConfiguration(buildSchema)
                .ExposeConfiguration(AddProxyConfiguration)
                .Database(configurer)
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Movie>()))
                .BuildSessionFactory();
        }

        /// <summary>
        /// Adds the configuration for the proxy
        /// </summary>
        /// <param name="config">Configuration instance to use</param>
        private static void AddProxyConfiguration(Configuration config)
        {
            config.Properties["proxyfactory.factory_class"] = "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle";
        }
    }
}