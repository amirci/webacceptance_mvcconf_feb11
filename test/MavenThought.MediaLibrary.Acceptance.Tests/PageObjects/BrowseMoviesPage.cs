using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MavenThought.Commons.Extensions;
using MavenThought.MediaLibrary.Acceptance.Tests.Utility;

namespace MavenThought.MediaLibrary.Acceptance.Tests.PageObjects
{
    /// <summary>
    /// Abstraction over movies page
    /// </summary>
    public class BrowseMoviesPage
    {
        /// <summary>
        /// Gets all the movies in the page
        /// </summary>
        public IEnumerable<string> Listing
        {
            get
            {
                var elements = Browser.Instance.TableCells.Where(cell => cell.ClassName == "title");

                return elements.Select(e => e.InnerHtml.Trim());
            }
        }

        /// <summary>
        /// Finds text in the page
        /// </summary>
        /// <param name="regularExp">Regular expression to find</param>
        /// <returns>The text found that matches the regular expression</returns>
        public string Find(string regularExp)
        {
            return Browser.Instance.FindText(new Regex(regularExp));
        }

        /// <summary>
        /// Gets the image of the case for the movie
        /// </summary>
        /// <param name="title">Title of the movie</param>
        /// <returns>The image source for the case</returns>
        public bool HasEmptyCase(string title)
        {
            var element = Browser.Instance
                .TableCells
                .Find(cell => cell.ClassName == "title" && cell.InnerHtml.Trim() == title);

            return element != null && element.Parent.NextSibling.InnerHtml.Contains("Empty");
        }
    }
}