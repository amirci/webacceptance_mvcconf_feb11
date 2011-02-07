using System.Collections.Generic;
using System.Linq;
using MavenThought.MediaLibrary.Core;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Specification when adding the movie to the storage
    /// </summary>
    [Specification]
    public class When_persistent_movie_is_added_to_the_storage : PersistentMovieSpecification
    {
        /// <summary>
        /// Object to store
        /// </summary>
        private Movie _movie;
        /// <summary>
        /// Actual collection obtained
        /// </summary>
        private IList<Movie> _actual;

        /// <summary>
        /// Checks the movie is stored
        /// </summary>
        [It]
        public void Should_retrieve_same_movie()
        {
            this._actual.First().Title.Should().Be.EqualTo(this._movie.Title);
        }

        /// <summary>
        /// Checks the size of the collection
        /// </summary>
        [It]
        public void Should_have_only_one_element()
        {
            this._actual.Should().Have.Count.EqualTo(1);
        }

        /// <summary>
        /// Setup the movie we want to store
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._movie = new Movie() { Title = "Blazing Saddles" };
        }

        /// <summary>
        /// Store the movie
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.Sut.AutoCommit(session => session.Save(this._movie));
        }

        /// <summary>
        /// Retrieve the movie from the storage
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.List<Movie>();
        }
    }
}