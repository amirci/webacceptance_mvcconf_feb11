using System.Collections.Generic;

namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// User information
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Identification for the user in the system
        /// </summary>
        IUserIdentification Identification { get; }

        /// <summary>
        /// Collection of media belonging to the user
        /// </summary>
        IEnumerable<IMediaElement> MediaCollection { get; }

        /// <summary>
        /// Role of the user
        /// </summary>
        IUserRole Role { get; }
    }
}