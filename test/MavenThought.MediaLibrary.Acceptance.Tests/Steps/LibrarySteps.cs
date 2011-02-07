using System;
using MavenThought.Commons.Extensions;
using MavenThought.MediaLibrary.Core;
using TechTalk.SpecFlow;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps that involve accessing the library
    /// </summary>
    [Binding]
    public class LibrarySteps 
    {
        /// <summary>
        /// Setup no movies exist
        /// </summary>
        [Given(@"I have no movies")]
        public void ClearMovies()
        {
            Utility.Storage.Instance.Clear();
        }
        
        /// <summary>
        /// Setup the movies in the library
        /// </summary>
        [Given(@"I have the following movies:")]
        public void SetupMovies(Table movies)
        {
            movies.Rows.ForEach(row => AddMovieToStorage(row["title"]));
        }

        /// <summary>
        /// Adds a movie to the media library
        /// </summary>
        /// <param name="title">Title of the movie to add</param>
        private static void AddMovieToStorage(string title)
        {
            var movie = new Movie
                            {
                                Title = title,
                                ReleaseDate = DateTime.Now
                            };

            Utility.Storage.Instance.Add(movie);
        }
    }
}
