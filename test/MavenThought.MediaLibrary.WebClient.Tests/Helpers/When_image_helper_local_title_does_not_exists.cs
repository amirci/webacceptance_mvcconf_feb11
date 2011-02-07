using System.IO;
using MavenThought.MediaLibrary.WebClient.Helpers;
using MavenThought.Commons.Testing;
using MbUnit.Framework;
using Rhino.Mocks;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests.Helpers
{
    /// <summary>
    /// Specification when the title exists
    /// </summary>
    [Specification]
    public class When_image_helper_local_title_does_not_exists : ImageHelperSpecification
    {
        /// <summary>
        /// Title to use
        /// </summary>
        private readonly string _title;

        /// <summary>
        /// Path to store the images
        /// </summary>
        private string _path;

        /// <summary>
        /// Initializes a new instance of <see cref="When_image_helper_local_title_does_not_exists"/> class.
        /// </summary>
        /// <param name="title">Title to use</param>
        public When_image_helper_local_title_does_not_exists([RandomStrings(Count = 10, Pattern = "The Adventures of [a-z]{8}")] string title)
        {
            _title = title;
        }

        /// <summary>
        /// Checks the default empty image tag is returned
        /// </summary>
        [It]
        public void Should_return_the_default_image_tag()
        {
            this.Actual.Should().Contain(ImageHelper.EmptyDvdCase);
        }

        /// <summary>
        /// Setup the title
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var randomDir = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());

            this._path = Path.Combine(Path.GetTempPath(), randomDir);

            this.Request
                .Stub(r => r.PhysicalApplicationPath)
                .Return(this._path);

            // Setup the path for local images
            var localPath = Path.Combine(this._path, ImageHelper.LocalImagePath.Substring(1));

            Directory.CreateDirectory(localPath);
        }

        /// <summary>
        /// Gets the image 
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Helper.LocalImage(this._title);
        }
    }
}