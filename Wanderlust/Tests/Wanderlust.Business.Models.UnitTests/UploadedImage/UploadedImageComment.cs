using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Models.UnitTests.UploadedImage
{
    [TestFixture]
    public class UploadedImageComment
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int commentId)
        {
            // Arrange & Act
            var imageComment = new UploadedImageComments.UploadedImageComment() { Id = commentId };

            //Assert
            Assert.AreEqual(commentId, imageComment.Id);
        }

        [TestCase("yeuyeuye eytruetryetrye retreryeryer")]
        [TestCase("LozenecLozenecLozenecLozenecLozenecLozenecLozenecLozenec")]
        public void Content_ShouldBeSetAndGottenCorrectly(string content)
        {
            // Arrange & Act
            var imageComment = new UploadedImageComments.UploadedImageComment() { Content = content };

            //Assert
            Assert.AreEqual(content, imageComment.Content);
        }

        [Test]
        public void Content_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var contentProperty = typeof(UploadedImageComments.UploadedImageComment).GetProperty("Content");

            // Act
            var minLengthAttribute = contentProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.CommentMinLength));
        }

        [Test]
        public void Content_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var contentProperty = typeof(UploadedImageComments.UploadedImageComment).GetProperty("Content");

            // Act
            var maxLengthAttribute = contentProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.CommentMaxLength));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var imageComment = new UploadedImageComments.UploadedImageComment() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(isDeleted, imageComment.IsDeleted);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void Author_ShouldBeSetAndGottenCorrectly(string testAuthorId)
        {
            // Arrange & Act         
            var user = new RegularUser { Id = testAuthorId };
            var imageComment = new UploadedImageComments.UploadedImageComment { Author = user };

            //Assert
            Assert.AreEqual(testAuthorId, imageComment.Author.Id);
        }

        [TestCase("rhrerherejrgejhr")]
        [TestCase("3882739739778")]
        public void AuthorId_ShouldBeSetAndGottenCorrectly(string userId)
        {
            // Arrange & Act
            var imageComment = new UploadedImageComments.UploadedImageComment { AuthorId = userId };

            //Assert
            Assert.AreEqual(userId, imageComment.AuthorId);
        }

        [TestCase("2012-12-3")]
        [TestCase("2017-11-23")]
        public void DateCreated_ShouldBeSetAndGottenCorrectly(DateTime date)
        {
            // Arrange & Act
            var imageComment = new UploadedImageComments.UploadedImageComment { DateCreated = date };

            //Assert
            Assert.AreEqual(date, imageComment.DateCreated);
        }

        [TestCase(232)]
        [TestCase(12)]
        public void UploadedImage_ShouldBeSetAndGottenCorrectly(int uploadedImageId)
        {
            // Arrange & Act         
            var image = new UploadedImages.UploadedImage { Id = uploadedImageId };
            var imageComment = new UploadedImageComments.UploadedImageComment { UploadedImage = image };

            //Assert
            Assert.AreEqual(uploadedImageId, imageComment.UploadedImage.Id);
        }

        [TestCase(1)]
        [TestCase(3232323)]
        public void UploadedImageId_ShouldBeSetAndGottenCorrectly(int uploadedImageId)
        {
            // Arrange & Act
            var imageComment = new UploadedImageComments.UploadedImageComment { UploadedImageId = uploadedImageId };

            //Assert
            Assert.AreEqual(uploadedImageId, imageComment.UploadedImageId);
        }
    }
}
