using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using MvcContrib.Castle;
using NHaml.Web.Mvc;
using Rhino.Commons.Binsor;
using Component = Castle.MicroKernel.Registration.Component;

namespace MavenThought.MediaLibrary.WebClient
{
    /// <summary>
    /// Main application
    /// </summary>
    public class MediaLibraryApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Gets the container used
        /// </summary>
        protected IWindsorContainer Container { get; private set; }

        /// <summary>
        /// Registers the routes
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Movies", action = "Index", id = "" }  // Parameter defaults
            );

        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        protected void Application_Start()
        {
            // Add nhaml engine
            ViewEngines.Engines.Add(new NHamlMvcViewEngine());

            // Setup IoC container
            this.SetupContainer();

            // Register the factory for the controllers
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(this.Container));
            
            // Register the routes
            RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// Setup the IoC container and register needed types
        /// </summary>
        private void SetupContainer()
        {
            this.Container = new WindsorContainer();

            this.Container.Register(Component.For<IWindsorContainer>().Instance(this.Container));

            BooReader.Read(this.Container, "Global.boo");
        }
    }
}