using NUnit.Framework;

namespace Wanderlust.Business.Models.UnitTests.UserRoles
{
    [TestFixture]
    public class Role
    {
        [Test]
        public void Role_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var role = new Models.UserRoles.Role();

            // Assert
            Assert.IsInstanceOf<Models.UserRoles.Role>(role);
        }

        [TestCase("Firm")]
        [TestCase("User")]
        public void Role_ShouldHaveConstructorWithNameParameter(string roleName)
        {
            // Arrange & Act
            var role = new Models.UserRoles.Role(roleName);

            // Assert
            Assert.IsInstanceOf<Models.UserRoles.Role>(role);
            Assert.AreEqual(roleName, role.Name);
        }

        [TestCase("eiiee eueieiouheyu")]
        public void RoleDescription_ShouldBeSetAndGottenCorrectly(string description)
        {
            // Arrange & Act
            var role = new Models.UserRoles.Role { Description = description };

            //Assert
            Assert.AreEqual(description, role.Description);
        }
    }
}
