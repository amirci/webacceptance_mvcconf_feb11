namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// Engine to find reviews for media
    /// </summary>
    public interface IReviewEngine
    {
        /// <summary>
        /// Finds the review for the media
        /// </summary>
        /// <param name="media">Media to search for</param>
        /// <returns>The review found or <c>null</c></returns>
        IMediaReview Find(IMediaElement media);
    }
}