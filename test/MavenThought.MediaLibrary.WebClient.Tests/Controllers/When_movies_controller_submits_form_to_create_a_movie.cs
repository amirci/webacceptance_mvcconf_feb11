using MavenThought.Commons;
using MavenThought.MediaLibrary.Domain;
using MvcContrib.TestHelper;
using MavenThought.Commons.Testing;
using Rhino.Mocks;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// Specification when submiting a form to create a new movie
    /// </summary>
    [Specification]
    public class When_movies_controller_submits_form_to_create_a_movie : MoviesControllerSpecification
    {
        private string _title;

        /// <summary>
        /// Checks the redirection goes to index
        /// </summary>
        [It]
        public void Should_redirect_the_result_to_index()
        {
            this.ActualResult.AssertHttpRedirect().ToUrl("Index");
        }

        /// <summary>
        /// Checks the movie is added
        /// </summary>
        [It]
        public void Should_add_the_movie_to_the_library()
        {
            var movieWithSameTitle = Arg<IMovie>.Matches(m => m.Title == this._title);

            Dep<IMediaLibrary>().AssertWasCalled(lib => lib.Add(movieWithSameTitle));
        }

        /// <summary>
        /// Setup the title of the movie
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._title = new RandomGenerator().Generate<string>();
        }

        /// <summary>
        /// Submit the form to create the movie
        /// </summary>
        protected override void WhenIRun()
        {
            this.ActualResult = this.Sut.Create(this._title);
        }
    }
}