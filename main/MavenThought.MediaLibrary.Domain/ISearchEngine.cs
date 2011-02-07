using System.Collections.Generic;

namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// Search engine to find media
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Name of the search engine
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Find media elements by title
        /// </summary>
        /// <param name="title">Title to use</param>
        /// <returns>The collection of elements found</returns>
        IEnumerable<IMediaElement> Find(string title);
    }
}