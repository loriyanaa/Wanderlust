using ImageProcessor;
using Moq;
using NUnit.Framework;
using System;

namespace Wanderlust.Business.Services.UnitTests.ImageProcessorService
{
    [TestFixture]
    public class ProcessImage_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPhotoBytesParamIsNull()
        {
            //Arrange
            var imageFactoryMock = new Mock<ImageFactory>(MockBehavior.Strict, new object[] { false });
            var imageProcessorService = new Services.ImageProcessorService(imageFactoryMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => imageProcessorService.ProcessImage(null, 1, 2, ".format", 3));
        }

        [Test]
        public void ThrowArgumentException_WhenPhotoBytesParamIsEmpty()
        {
            //Arrange
            var imageFactoryMock = new Mock<ImageFactory>(MockBehavior.Strict, new object[] { false });
            var imageProcessorService = new Services.ImageProcessorService(imageFactoryMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => imageProcessorService.ProcessImage(new byte[] { }, 1, 2, ".format", 3));
        }

        [Test]
        public void ThrowArgumentNullException_WhenFileFormatParamIsNull()
        {
            //Arrange
            var imageFactoryMock = new Mock<ImageFactory>(MockBehavior.Strict, new object[] { false });
            var imageProcessorService = new Services.ImageProcessorService(imageFactoryMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => imageProcessorService.ProcessImage(new byte[] { 1 }, 1, 2, null, 3));
        }

        [Test]
        public void ThrowArgumentException_WhenFileFormatParamIsEmpty()
        {
            //Arrange
            var imageFactoryMock = new Mock<ImageFactory>(MockBehavior.Strict, new object[] { false });
            var imageProcessorService = new Services.ImageProcessorService(imageFactoryMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => imageProcessorService.ProcessImage(new byte[] { 1 }, 1, 2, string.Empty, 3));
        }
    }
}
