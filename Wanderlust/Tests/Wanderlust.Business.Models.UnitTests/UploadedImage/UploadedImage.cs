using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Models.UnitTests.UploadedImage
{
    [TestFixture]
    public class UploadedImage
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int imageId)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { Id = imageId };

            //Assert
            Assert.AreEqual(imageId, image.Id);
        }

        [TestCase("yeuyeuye eytruetryetrye retreryeryer")]
        [TestCase("LozenecLozenecLozenecLozenecLozenecLozenecLozenecLozenec")]
        public void Description_ShouldBeSetAndGottenCorrectly(string description)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { Description = description };

            //Assert
            Assert.AreEqual(description, image.Description);
        }

        [TestCase("Bulgaria")]
        [TestCase("Germany")]
        public void Country_ShouldBeSetAndGottenCorrectly(string country)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { Country = country };

            //Assert
            Assert.AreEqual(country, image.Country);
        }

        [TestCase("Veliko Tarnovo")]
        [TestCase("Sofia")]
        public void City_ShouldBeSetAndGottenCorrectly(string city)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { City = city };

            //Assert
            Assert.AreEqual(city, image.City);
        }

        [Test]
        public void Description_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var descriptionProperty = typeof(UploadedImages.UploadedImage).GetProperty("Description");

            // Act
            var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.UploadedImageDescriptionMaxLength));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(isDeleted, image.IsDeleted);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void Uploader_ShouldBeSetAndGottenCorrectly(string testUploaderId)
        {
            // Arrange & Act         
            var user = new RegularUser { Id = testUploaderId };
            var image = new UploadedImages.UploadedImage { Uploader = user };

            //Assert
            Assert.AreEqual(testUploaderId, image.Uploader.Id);
        }

        [TestCase("rhrerherejrgejhr")]
        [TestCase("3882739739778")]
        public void UploaderId_ShouldBeSetAndGottenCorrectly(string testUploaderId)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage { UploaderId = testUploaderId };

            //Assert
            Assert.AreEqual(testUploaderId, image.UploaderId);
        }

        [TestCase("2012-12-3")]
        [TestCase("2017-11-23")]
        public void DateUploaded_ShouldBeSetAndGottenCorrectly(DateTime date)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage { DateUploaded = date };

            //Assert
            Assert.AreEqual(date, image.DateUploaded);
        }

        [TestCase("index/pictures/photo.png")]
        [TestCase("index/pictures/photo.pngindex/pictures/photo.pngindex/pictures/photo.png")]
        public void ThumbnailSrc_ShouldBeSetAndGottenCorrectly(string src)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { ThumbnailSrc = src };

            //Assert
            Assert.AreEqual(src, image.ThumbnailSrc);
        }

        [TestCase("index/pictures/photo.png")]
        [TestCase("index/pictures/photo.pngindex/pictures/photo.pngindex/pictures/photo.png")]
        public void OriginalSrc_ShouldBeSetAndGottenCorrectly(string src)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { OriginalSrc = src };

            //Assert
            Assert.AreEqual(src, image.OriginalSrc);
        }

        //[TestCase(234)]
        //[TestCase(2)]
        //public void Country_ShouldBeSetAndGottenCorrectly(int testCountryId)
        //{
        //    // Arrange & Act         
        //    var country = new Country { Id = testCountryId };
        //    var image = new UploadedImages.UploadedImage { Country = country };

        //    //Assert
        //    Assert.AreEqual(testCountryId, image.Country.Id);
        //}

        //[TestCase(3)]
        //[TestCase(236)]
        //public void CointryId_ShouldBeSetAndGottenCorrectly(int countryId)
        //{
        //    // Arrange & Act
        //    var image = new UploadedImages.UploadedImage { CountryId = countryId };

        //    //Assert
        //    Assert.AreEqual(countryId, image.CountryId);
        //}

        //[TestCase(234)]
        //[TestCase(2)]
        //public void City_ShouldBeSetAndGottenCorrectly(int testCityId)
        //{
        //    // Arrange & Act         
        //    var city = new City { Id = testCityId };
        //    var image = new UploadedImages.UploadedImage { City = city };

        //    //Assert
        //    Assert.AreEqual(testCityId, image.City.Id);
        //}

        //[TestCase(3)]
        //[TestCase(236)]
        //public void CityId_ShouldBeSetAndGottenCorrectly(int cityId)
        //{
        //    // Arrange & Act
        //    var image = new UploadedImages.UploadedImage { CityId = cityId };

        //    //Assert
        //    Assert.AreEqual(cityId, image.CityId);
        //}

        [TestCase(12344)]
        [TestCase(0)]
        public void LikesCount_ShouldBeSetAndGottenCorrectly(int likesCount)
        {
            // Arrange & Act
            var image = new UploadedImages.UploadedImage() { LikesCount = likesCount };

            //Assert
            Assert.AreEqual(likesCount, image.LikesCount);
        }

        [Test]
        public void UploadedImageConstructor_ShouldInitializeUploadedImageCommentsCollectionCorrectly()
        {
            //Arrange
            var image = new UploadedImages.UploadedImage();

            //Act
            var comments = image.Comments;

            //Assert
            Assert.That(comments, Is.Not.Null.And.InstanceOf<ICollection<UploadedImageComments.UploadedImageComment>>());
        }

        [TestCase(87)]
        [TestCase(342)]
        public void CommentsCollection_ShouldBeSetAndGottenCorrectly(int commentId)
        {
            //Arrange
            var comment = new UploadedImageComments.UploadedImageComment() { Id = commentId };
            var set = new List<UploadedImageComments.UploadedImageComment> { comment };
            var image = new UploadedImages.UploadedImage { Comments = set };

            Assert.AreEqual(image.Comments.First().Id, commentId);
        }
    }
}
