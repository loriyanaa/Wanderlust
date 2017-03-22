using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wanderlust.Business.Common;

namespace Wanderlust.Business.Models.UnitTests.Locations
{
    [TestFixture]
    public class Country
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int countryId)
        {
            // Arrange & Act
            var country = new Models.Locations.Country() { Id = countryId };

            //Assert
            Assert.AreEqual(countryId, country.Id);
        }

        [TestCase("eiiee eueieiouheyu")]
        public void CountryName_ShouldBeSetAndGottenCorrectly(string name)
        {
            // Arrange & Act
            var country = new Models.Locations.Country { Name = name };

            //Assert
            Assert.AreEqual(name, country.Name);
        }

        [Test]
        public void CountryName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Models.Locations.Country).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.NameMinLength));
        }

        [Test]
        public void CountryName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Models.Locations.Country).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.NameMaxLength));
        }

        [Test]
        public void Country_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var country = new Country();

            // Assert
            Assert.IsInstanceOf<Country>(country);
        }

        [Test]
        public void CountryConstructor_ShouldInitializeCitiesCollectionCorrectly()
        {
            var country = new Models.Locations.Country();

            var cities = country.Cities;

            Assert.That(cities, Is.Not.Null.And.InstanceOf<ICollection<Models.Locations.City>>());
        }

        [TestCase(456)]
        [TestCase(21)]
        public void CitiesCollection_ShouldBeSetAndGottenCorrectly(int cityId)
        {
            var city = new Models.Locations.City() { Id = cityId };
            var set = new List<Models.Locations.City> { city };

            var country = new Models.Locations.Country { Cities = set };

            Assert.AreEqual(cityId, country.Cities.First().Id);
        }
    }
}
