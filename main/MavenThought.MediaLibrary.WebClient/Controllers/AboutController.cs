using System.Web.Mvc;

namespace MavenThought.MediaLibrary.WebClient.Controllers
{
    /// <summary>
    /// Controller for main page
    /// </summary>
    public class AboutController : Controller
    {
        /// <summary>
        /// Index method associated to GET: /Home/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}
