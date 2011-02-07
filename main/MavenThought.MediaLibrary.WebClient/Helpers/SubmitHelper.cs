using System.Web.Mvc;

namespace MavenThought.MediaLibrary.WebClient.Helpers
{
    /// <summary>
    /// Helper to generate submit button
    /// </summary>
    public static class SubmitHelper
    {
        /// <summary>
        /// Generates a submit button
        /// </summary>
        /// <param name="helper">Helper to extend</param>
        /// <param name="value">Value for the submit button</param>
        /// <returns>A submit tag</returns>
        public static string Submit(this HtmlHelper helper, string value)
        {
            // Create tag builder  
            var builder = new TagBuilder("input");

            // Create valid id  
            builder.GenerateId(value);

            // Add attributes  
            builder.MergeAttribute("type", "submit");
            builder.MergeAttribute("name", value);
            builder.MergeAttribute("value", value);

            // Render tag  
            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}