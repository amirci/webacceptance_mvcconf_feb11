import System.Web.Mvc
import MavenThought.MediaLibrary.WebClient.Controllers
import MavenThought.MediaLibrary.Storage.NHibernate
import MavenThought.MediaLibrary.Domain

component "HomeController", HomeController:
  @lifestyle = "transient"

component "MoviesController", MoviesController:
  @lifestyle = "transient"
  
component "AboutController", AboutController:
  @lifestyle = "transient"

component IMediaLibrary, StorageMediaLibrary:
  databaseFile = "C:/temp/movielib.db"
