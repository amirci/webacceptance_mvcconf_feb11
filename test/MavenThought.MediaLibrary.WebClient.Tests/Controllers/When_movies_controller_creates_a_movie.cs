using MvcContrib.TestHelper;
using MavenThought.Commons.Testing;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// Specification when creating the form to enter a movie
    /// </summary>
    [Specification]
    public class When_movies_controller_creates_a_movie : MoviesControllerSpecification
    {
        /// <summary>
        /// Checks the view is rendered
        /// </summary>
        [It]
        public void Should_return_the_view()
        {
            this.ActualResult.AssertViewRendered();
        }

        /// <summary>
        /// Call the create method to present the form
        /// </summary>
        protected override void WhenIRun()
        {
            this.ActualResult = this.Sut.Create();
        }
    }
}