using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MavenThought.MediaLibrary.Core;
using MavenThought.MediaLibrary.Domain;
using NHibernate;
using Rhino.Mocks;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Specification when getting contents from the library
    /// </summary>
    [Specification]
    public class When_storage_library_gets_contents : StorageMediaLibrarySpecification
    {
        /// <summary>
        /// Actual contents obtained
        /// </summary>
        private IEnumerable<IMovie> _actual;

        /// <summary>
        /// Expected collection
        /// </summary>
        private IList<Movie> _expected;

        /// <summary>
        /// Checks the contents match the expected
        /// </summary>
        [It]
        public void Should_return_the_expected_contents()
        {
            this._expected.Cast<IMovie>().Should().Have.SameSequenceAs(this._actual);
        }

        /// <summary>
        /// Setup the session and expected movies
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            Stub<ISessionFactory, ISession>(f => f.OpenSession());

            Stub<ISession, ICriteria>(s => s.CreateCriteria(typeof(Movie)));

            this._expected = 10.Times(() => new Movie()).ToList();

            Dep<ICriteria>().Stub(c => c.List<Movie>()).Return(this._expected);
        }

        /// <summary>
        /// Gets the contents from the library
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.Contents;
        }
    }
}