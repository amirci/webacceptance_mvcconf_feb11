namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// Person information
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// First name of the person
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Last name of the person
        /// </summary>
        string LastName { get; }
    }
}