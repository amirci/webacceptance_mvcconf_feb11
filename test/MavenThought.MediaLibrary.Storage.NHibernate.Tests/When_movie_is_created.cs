using FluentNHibernate.Testing;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Core;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Specification when persistent product is created
    /// </summary>
    [ConstructorSpecification]
    public class When_movie_is_created : PersistentMovieSpecification
    {
        /// <summary>
        /// Validates the mapping
        /// </summary>
        [It]
        public void Should_have_the_right_mappings()
        {
            this.Sut.AutoSession(s =>
                                     new PersistenceSpecification<Movie>(s)
                                         .CheckProperty(p => p.Title, "Space Balls")
                                         .VerifyTheMappings());
        }
    }
}