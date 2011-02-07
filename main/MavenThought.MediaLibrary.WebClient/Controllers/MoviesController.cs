using System;
using System.Linq;
using System.Web.Mvc;
using MavenThought.MediaLibrary.Core;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.WebClient.Controllers
{
    /// <summary>
    /// Controller for movies
    /// </summary>
    public class MoviesController : Controller
    {
        /// <summary>
        /// Library instance
        /// </summary>
        private readonly IMediaLibrary _library;

        /// <summary>
        /// Initializes the controller
        /// </summary>
        /// <param name="library">Library to use</param>
        public MoviesController(IMediaLibrary library)
        {
            _library = library;
        }

        /// <summary>
        /// Gets the list of movies GET : /Movies/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(this._library.Contents.ToList());
        }

        /// <summary>
        /// Creates the form to add a movie
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds a movie to the library using the title
        /// </summary>
        /// <param name="title">Title to use for the movie</param>
        /// <returns>Redirect to the index</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string title)
        {
            this._library.Add(new Movie { Title = title });

            return Redirect("Index");
        }
    }
}
