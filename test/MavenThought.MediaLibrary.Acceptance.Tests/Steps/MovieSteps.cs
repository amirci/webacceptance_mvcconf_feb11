using System;
using MavenThought.MediaLibrary.Acceptance.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps related to movie
    /// </summary>
    [Binding]
    public class MovieSteps
    {
        /// <summary>
        /// Instance of add movie page
        /// </summary>
        private readonly AddMoviePage _page;

        public MovieSteps()
        {
            this._page = new AddMoviePage();
        }
    
        /// <summary>
        /// Enter the title
        /// </summary>
        [When(@"I enter ""(.*)"" in the title")]
        public void EnterTheTitle(string title)
        {
            this._page.Title = title;
        }

        /// <summary>
        /// Submit the form
        /// </summary>
        [When(@"I click Submit")]
        public void SubmitForm()
        {
            this._page.Submit();
        }
    }
}