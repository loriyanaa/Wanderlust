using NUnit.Framework;

namespace Wanderlust.WebClient.UnitTests.Controllers.HomeController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateHomeController()
        {
            // Arrange
            var homeController = new WebClient.Controllers.HomeController();

            //Act & Assert
            Assert.That(homeController, Is.InstanceOf<WebClient.Controllers.HomeController>());
        }
    }
}
