﻿using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Models.UnitTests.Users
{
    [TestFixture]
    public class User
    {
        [Test]
        public void Username_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var usernameProperty = typeof(RegularUser).GetProperty("Username");

            // Act
            var minLengthAttribute = usernameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.NameMinLength));
        }

        [Test]
        public void Username_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var usernameProperty = typeof(RegularUser).GetProperty("Username");

            // Act
            var maxLengthAttribute = usernameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(GlobalConstants.NameMaxLength));
        }

        [TestCase("Ivan")]
        [TestCase("Blagoi")]
        public void Username_ShouldBeSetAndGottenCorrectly(string testName)
        {
            // Arrange & Act
            var user = new RegularUser() { Username = testName };

            //Assert
            Assert.AreEqual(user.Username, testName);
        }

        [TestCase("uuseerTeest123")]
        [TestCase("someRandomAvatarUrl")]
        public void AvatarUrl_ShouldBeSetAndGottenCorrectly(string url)
        {
            //Arrange & Act
            var user = new RegularUser() { AvatarUrl = url };

            //Assert
            Assert.AreEqual(url, user.AvatarUrl);
        }

        [TestCase("pesho@abv.bg")]
        public void Email_ShouldBeSetAndGottenCorrectly(string email)
        {
            // Arrange & Act
            var user = new RegularUser() { Email = email };

            //Assert
            Assert.AreEqual(user.Email, email);
        }

        [TestCase("randomstringhrrhhyeueeyeegge")]
        public void UserInfo_ShouldBeSetAndGottenCorrectly(string info)
        {
            // Arrange & Act
            var user = new RegularUser() { UserInfo = info };

            //Assert
            Assert.AreEqual(user.UserInfo, info);
        }

        [TestCase("facebook.com/pesho")]
        public void FacebookProfile_ShouldBeSetAndGottenCorrectly(string fb)
        {
            // Arrange & Act
            var user = new RegularUser() { FacebookProfile = fb };

            //Assert
            Assert.AreEqual(user.FacebookProfile, fb);
        }

        [TestCase("37827383hg37362g372")]
        [TestCase("382-82328-j3j3828h")]
        public void Id_ShouldBeSetAndGottenCorrectly(string userId)
        {
            // Arrange & Act
            var user = new RegularUser() { Id = userId };

            //Assert
            Assert.AreEqual(user.Id, userId);
        }

        [TestCase(20)]
        [TestCase(45)]
        public void Age_ShouldBeSetAndGottenCorrectly(int testAge)
        {
            // Arrange & Act
            var user = new RegularUser() { Age = testAge };

            //Assert
            Assert.AreEqual(user.Age, testAge);
        }

        [TestCase(0)]
        [TestCase(183732)]
        public void Posts_ShouldBeSetAndGottenCorrectly(int posts)
        {
            // Arrange & Act
            var user = new RegularUser() { Posts = posts };

            //Assert
            Assert.AreEqual(user.Posts, posts);
        }

        [Test]
        public void RegularUser_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var user = new RegularUser();

            // Assert
            Assert.IsInstanceOf<RegularUser>(user);
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeFollowersCollectionCorrectly()
        {
            var user = new RegularUser();

            var reviews = user.Followers;

            Assert.That(reviews, Is.Not.Null.And.InstanceOf<ICollection<RegularUser>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeFollowingCollectionCorrectly()
        {
            var user = new RegularUser();

            var starredUsers = user.Following;

            Assert.That(starredUsers, Is.Not.Null.And.InstanceOf<ICollection<RegularUser>>());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            //Arrange & Act
            var user = new RegularUser { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(isDeleted, user.IsDeleted);
        }

        [TestCase("heuehu3738trg3")]
        [TestCase("r3gyrg3675375376rtf")]
        public void FollowersCollection_ShouldBeSetAndGottenCorrectly(string followerId)
        {
            //Arrange
            var follower = new RegularUser() { Id = followerId };
            var set = new List<RegularUser> { follower };

            //Act
            var user = new RegularUser { Followers = set };

            //Assert
            Assert.AreEqual(user.Followers.First().Id, followerId);
        }

        [TestCase("heuehu3738trg3")]
        [TestCase("r3gyrg3675375376rtf")]
        public void FollowingCollection_ShouldBeSetAndGottenCorrectly(string followingId)
        {
            //Arrange
            var following = new RegularUser() { Id = followingId };
            var set = new List<RegularUser> { following };

            //Act
            var user = new RegularUser { Following = set };

            //Assert
            Assert.AreEqual(user.Following.First().Id, followingId);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void ApplicationUser_ShouldBeSetAndGottenCorrectly(string testUserId)
        {
            // Arrange & Act         
            var user = new ApplicationUser { Id = testUserId };
            var regularUser = new RegularUser { ApplicationUser = user };

            //Assert
            Assert.AreEqual(regularUser.ApplicationUser.Id, testUserId);
        }
    }
}
