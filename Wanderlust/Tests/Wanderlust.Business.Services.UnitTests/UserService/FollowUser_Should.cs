﻿using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UserService
{
    [TestFixture]
    public class FollowUser_Should
    {
        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => regularUserService.FollowUser(string.Empty, "rerer"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.FollowUser(null, "rrrrr"));
        }
    }
}
