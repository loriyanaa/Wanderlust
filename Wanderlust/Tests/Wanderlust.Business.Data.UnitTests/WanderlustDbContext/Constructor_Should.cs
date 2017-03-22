using NUnit.Framework;
using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data.UnitTests.WanderlustDbContext
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateObjectOfTypeIWanderlustDbContext()
        {
            //Arange && Act
            var dbContext = new Data.WanderlustEfDbContext();

            //Assert
            Assert.IsInstanceOf<IWanderlustEfDbContext>(dbContext);
        }
    }
}
