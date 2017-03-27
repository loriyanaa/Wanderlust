using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Wanderlust.WebClient.UnitTests.Controllers.HomeController
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var homeController = new WebClient.Controllers.HomeController();

            // Act & Assert
            homeController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}