using System;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.Core
{
    /// <summary>
    /// Implementation of movie media element
    /// </summary>
    public class Movie : IMovie
    {
        /// <summary>
        /// Gets or sets the id of the movie
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Title for the media element
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// The release date of the media
        /// </summary>
        public virtual DateTime? ReleaseDate { get; set; }
    }
}