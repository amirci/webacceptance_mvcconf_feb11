using System.Web.Mvc;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.WebClient.Controllers;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// Base specification for MoviesController
    /// </summary>
    public abstract class MoviesControllerSpecification
        : AutoMockSpecificationWithNoContract<MoviesController>
    {
        protected ActionResult ActualResult { get; set; }
    }
}