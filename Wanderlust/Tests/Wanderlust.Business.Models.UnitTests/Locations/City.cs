using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.Locations;

namespace Wanderlust.Business.Models.UnitTests.Locations
{
    [TestFixture]
    public class City
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int cityId)
        {
            // Arrange & Act
            var city = new Models.Locations.City() { Id = cityId };

            //Assert
            Assert.AreEqual(cityId, city.Id);
        }

        [TestCase("eiiee eueieiouheyu")]
        public void CityName_ShouldBeSetAndGottenCorrectly(string name)
        {
            // Arrange & Act
            var city = new Models.Locations.City { Name = name };

            //Assert
            Assert.AreEqual(name, city.Name);
        }

        [Test]
        public void CityName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Models.Locations.City).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.NameMinLength));
        }

        [Test]
        public void CityName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Models.Locations.City).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.NameMaxLength));
        }

        [TestCase(234)]
        [TestCase(2)]
        public void Country_ShouldBeSetAndGottenCorrectly(int testCountryId)
        {
            // Arrange & Act         
            var country = new Models.Locations.Country { Id = testCountryId };
            var city = new Models.Locations.City { Country = country };

            //Assert
            Assert.AreEqual(testCountryId, city.Country.Id);
        }

        [TestCase(3)]
        [TestCase(236)]
        public void CointryId_ShouldBeSetAndGottenCorrectly(int countryId)
        {
            // Arrange & Act
            var city = new Models.Locations.City { CountryId = countryId };

            //Assert
            Assert.AreEqual(countryId, city.CountryId);
        }
    }
}
