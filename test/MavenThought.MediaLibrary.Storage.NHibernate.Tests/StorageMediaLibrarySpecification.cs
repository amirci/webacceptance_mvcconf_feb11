using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using NHibernate;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// StorageMediaLibrary specification
    /// </summary>
    public abstract class StorageMediaLibrarySpecification
        : AutoMockSpecification<StorageMediaLibrary, IMediaLibrary>
    {
        /// <summary>
        /// Creates the media library using the session factory dependency
        /// </summary>
        /// <returns>An instance to storage media library</returns>
        protected override IMediaLibrary CreateSut()
        {
            return new StorageMediaLibrary(Dep<ISessionFactory>());
        }
    }
}