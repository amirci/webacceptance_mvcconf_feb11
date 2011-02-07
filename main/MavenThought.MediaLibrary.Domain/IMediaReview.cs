namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// Review information for the media
    /// </summary>
    public interface IMediaReview
    {
        /// <summary>
        /// Review information
        /// </summary>
        string Review { get; }
    }
}