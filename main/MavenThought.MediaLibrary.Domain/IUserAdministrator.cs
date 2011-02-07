using System.Collections.Generic;

namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// User administrator model
    /// </summary>
    public interface IUserAdministrator
    {
        /// <summary>
        /// Gets the users registered in the media library
        /// </summary>
        IEnumerable<IUser> Users { get; }

        /// <summary>
        /// Adds a new user to the media library
        /// </summary>
        /// <param name="user">User to add</param>
        void RegisterUser(IUser user);
    }
}