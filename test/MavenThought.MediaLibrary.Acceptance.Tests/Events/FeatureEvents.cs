using MavenThought.MediaLibrary.Acceptance.Tests.Utility;
using TechTalk.SpecFlow;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Events
{
    /// <summary>
    /// Events for scenarios and steps
    /// </summary>
    [Binding]
    public class FeatureEvents
    {
        /// <summary>
        /// Clear the library before the scenario runs
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            Utility.Storage.Instance.Clear(); 
        }

        /// <summary>
        /// Pending
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }

        /// <summary>
        /// Setup the browser
        /// </summary>
        [BeforeFeature]
        public static void BeforeFeature()
        {
            Browser.InitializeBrowser();
        }

        /// <summary>
        /// Close the browser
        /// </summary>
        [AfterFeature]
        public static void AfterFeature()
        {
            Browser.ShutdownBrowser();
        }
    }
}


