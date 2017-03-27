using NUnit.Framework;

namespace Wanderlust.Business.Models.UnitTests.Users
{
    [TestFixture]
    public class Admin
    {
        [TestCase("37827383hg37362g372")]
        [TestCase("382-82328-j3j3828h")]
        public void Id_ShouldBeSetAndGottenCorrectly(string userId)
        {
            // Arrange & Act
            var user = new Models.Users.Admin() { Id = userId };

            //Assert
            Assert.AreEqual(userId, user.Id);
        }
    }
}
