using System.Web;
using System.Web.Mvc;
using MavenThought.Commons.Testing;
using Rhino.Mocks;

namespace MavenThought.MediaLibrary.WebClient.Tests.Helpers
{
    /// <summary>
    /// Base specification for ImageHelper
    /// </summary>
    public abstract class ImageHelperSpecification
        : BaseSpecification
    {
        /// <summary>
        /// Helper class to extend
        /// </summary>
        protected HtmlHelper Helper { get; private set; }

        /// <summary>
        /// Actual value obtained
        /// </summary>
        protected string Actual { get; set; }

        /// <summary>
        /// Gets the request info
        /// </summary>
        protected HttpRequestBase Request { get; private set; }

        /// <summary>
        /// Setup the helper
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var httpContext = Mock<HttpContextBase>();

            this.Request = Mock<HttpRequestBase>();

            httpContext.Stub(ctx => ctx.Request).Return(this.Request);

            var viewContext = new ViewContext { HttpContext = httpContext };

            this.Helper = new HtmlHelper(viewContext, Mock<IViewDataContainer>());
        }

    }
}