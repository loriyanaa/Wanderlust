using Moq;
using NUnit.Framework;
using System;
using System.IO;

namespace Wanderlust.Business.Services.UnitTests.FileSaverService
{
    [TestFixture]
    public class SaveFile_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenFileToSaveParamIsNull()
        {
            //Arrange
            var fileSaverService = new Services.FileSaverService();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => fileSaverService.SaveFile(null, "dirToSaveIn", "fileName"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenDirToSaveInParamIsNull()
        {
            //Arrange
            var fileSaverService = new Services.FileSaverService();
            var memoryStream = new Mock<MemoryStream>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => fileSaverService.SaveFile(memoryStream.Object, null, "fileName"));
        }

        [Test]
        public void ThrowArgumentException_WhenDirToSaveInParamIsEmpty()
        {
            //Arrange
            var fileSaverService = new Services.FileSaverService();
            var memoryStream = new Mock<MemoryStream>();

            //Act && Assert
            Assert.Throws<ArgumentException>(() => fileSaverService.SaveFile(memoryStream.Object, string.Empty, "fileName"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenFileNameParamIsNull()
        {
            //Arrange
            var fileSaverService = new Services.FileSaverService();
            var memoryStream = new Mock<MemoryStream>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => fileSaverService.SaveFile(memoryStream.Object, "dirToSaveIn", null));
        }

        [Test]
        public void ThrowArgumentException_WhenFileNameParamIsEmpty()
        {
            //Arrange
            var fileSaverService = new Services.FileSaverService();
            var memoryStream = new Mock<MemoryStream>();

            //Act && Assert
            Assert.Throws<ArgumentException>(() => fileSaverService.SaveFile(memoryStream.Object, "dirToSaveIn", string.Empty));
        }
    }
}
