namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// User identification information
    /// </summary>
    public interface IUserIdentification
    {
        /// <summary>
        /// Login of the user in the system
        /// </summary>
        string Login { get; }

        /// <summary>
        /// Password of the user in the system
        /// </summary>
        string Password { get; }
    }
}