﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UserService
{
    [TestFixture]
    class GetNumberOfFollowersForUser_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.GetNumberOfFollowersForUser(null));
        }
    }
}
