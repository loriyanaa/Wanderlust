using NUnit.Framework;
using System.Data.Entity.Migrations;

namespace Wanderlust.Business.Data.UnitTests.Migrations
{
    [TestFixture]
    public class Configuration
    {
        [Test]
        public void Constructor_ShouldCreateObjectOfTypeDbMigrationsConfiguration()
        {
            //Arange && Act
            var configuration = new Data.Migrations.Configuration();

            //Assert
            Assert.IsInstanceOf<DbMigrationsConfiguration<Data.WanderlustDbContext>>(configuration);
        }
    }
}
