using System.Linq;
using MavenThought.MediaLibrary.Acceptance.Tests.PageObjects;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps to implement browse movie feature
    /// </summary>
    [Binding]
    public class ListingSteps
    {
        /// <summary>
        /// Setup the movies page
        /// </summary>
        public ListingSteps()
        {
            this.Page = new BrowseMoviesPage();
        }

        /// <summary>
        /// Gets the movies page
        /// </summary>
        protected BrowseMoviesPage Page { get; private set; }

        /// <summary>
        /// Checks the movie is in the listing
        /// </summary>
        /// <param name="movies">Movies to look for</param>
        [Then(@"I should see in the listing:")]
        public void AssertListingContains(Table movies)
        {
            var expected = movies.Rows.Select(row => row["title"]);

            var listing = this.Page.Listing;

            listing.Should().Have.SameSequenceAs(expected);
        }

        /// <summary>
        /// Checks the movie is in the listing
        /// </summary>
        /// <param name="title">Title to check for</param>
        [Then(@"I should see ""(.*)"" in the listing")]
        public void AssertListingContains(string title)
        {
            var listing = this.Page.Listing;

            listing.Should().Contain(title);
        }

        /// <summary>
        /// Checks no movies are shown
        /// </summary>
        [Then(@"I should see the message ""(.*)""")]
        public void AssertPageContains(string message)
        {
            this.Page.Find(message).Should().Not.Be.Null();
        }

 
    }
}


