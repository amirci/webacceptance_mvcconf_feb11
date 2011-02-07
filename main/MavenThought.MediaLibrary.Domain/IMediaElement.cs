using System;

namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// Media element
    /// </summary>
    public interface IMediaElement
    {
        /// <summary>
        /// Title for the media element
        /// </summary>
        string Title { get; }

        /// <summary>
        /// The release date of the media
        /// </summary>
        DateTime? ReleaseDate { get; set; }

    }
}
