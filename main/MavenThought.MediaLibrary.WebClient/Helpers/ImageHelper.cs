using System.IO;
using System.Web.Mvc;
using System.Web.Routing;

namespace MavenThought.MediaLibrary.WebClient.Helpers
{
    /// <summary>
    /// Image helper for <see cref="HtmlHelper"/> class.
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Path for local images 
        /// </summary>
        public const string LocalImagePath = @"/Content/Images/Local/";

        /// <summary>
        /// Image to use when the local image is not found
        /// </summary>
        public const string EmptyDvdCase = @"Empty DVD case";

        /// <summary>
        /// Gets the default extension for local images
        /// </summary>
        public const string DefaultExtension = @".jpg";

        /// <summary>
        /// Generates a tag for a local image
        /// </summary>
        /// <param name="helper">Helper to use</param>
        /// <param name="movieTitle">Title to use</param>
        /// <returns>An image tag pointing to the right local image</returns>
        public static string LocalImage(this HtmlHelper helper, string movieTitle)
        {
            var contentPath = string.Format("{0}{1}{2}", LocalImagePath, movieTitle, DefaultExtension);

            var actualUrl = UrlHelper.GenerateContentUrl(contentPath, helper.ViewContext.HttpContext);

            var root = helper.ViewContext.HttpContext.Request.PhysicalApplicationPath;

            var actualFile = root + actualUrl;

            var exists = File.Exists(actualFile);

            if (!exists)
            {
                actualUrl = string.Format("{0}{1}{2}", LocalImagePath, EmptyDvdCase, DefaultExtension);
            }

            return Image(helper, actualUrl);
        }

        /// <summary>
        /// Generates an image tag
        /// </summary>
        /// <param name="helper">Helper instance</param>
        /// <param name="url">URL to use</param>
        /// <returns>The string with the tag</returns>
        public static string Image(this HtmlHelper helper, string url)
        {
            return Image(helper, "", url, "image");
        }

        /// <summary>
        /// Creates an image tag
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="alternateText"></param>
        /// <returns></returns>
        public static string Image(this HtmlHelper helper, string id, string url, string alternateText)
        {
            return Image(helper, id, url, alternateText, null);
        }

        /// <summary>
        /// Creates an image tag
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="alternateText"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static string Image(this HtmlHelper helper, string id, string url, string alternateText, object htmlAttributes)
        {
            // Instantiate a UrlHelper   
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            // Create tag builder  
            var builder = new TagBuilder("img");

            // Create valid id  
            builder.GenerateId(id);

            // Add attributes  
            builder.MergeAttribute("src", urlHelper.Content(url));
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag  
            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}