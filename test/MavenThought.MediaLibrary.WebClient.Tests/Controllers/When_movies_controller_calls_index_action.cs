using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.MediaLibrary.Domain;
using MbUnit.Framework;
using MvcContrib.TestHelper;
using MavenThought.Commons.Testing;
using Rhino.Mocks;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// Specification when calling index action
    /// </summary>
    [Specification]
    public class When_movies_controller_calls_index_action : MoviesControllerSpecification
    {
        /// <summary>
        /// Contents of the library
        /// </summary>
        private IEnumerable<IMovie> _movies;

        /// <summary>
        /// Checks the view is index
        /// </summary>
        [Test]
        public void Should_return_to_index_view()
        {
            this.ActualResult.AssertViewRendered();
        }

        /// <summary>
        /// Checks the view has the model with the contents of the library
        /// </summary>
        [It]
        public void Should_set_the_model_the_contents_of_the_library()
        {
            var model = this.ActualResult.AssertViewRendered().WithViewData<IEnumerable<IMovie>>();

            model.Should().Have.SameSequenceAs(this._movies);
        }

        /// <summary>
        /// Setup the library contents
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._movies = 10.Times(() => Mock<IMovie>());

            Dep<IMediaLibrary>()
                .Stub(lib => lib.Contents)
                .Return(this._movies);
        }

        /// <summary>
        /// Call the index action
        /// </summary>
        protected override void WhenIRun()
        {
            this.ActualResult = this.Sut.Index();
        }
    }
}