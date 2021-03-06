﻿using NUnit.Framework;
using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data.UnitTests.WanderlustDbContext
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnObjectOfTypeIWanderlustDbContext()
        {
            //Arrange & Act
            var dbContext = Data.WanderlustEfDbContext.Create();

            //Assert
            Assert.IsInstanceOf<IWanderlustEfDbContext>(dbContext);
        }
    }
}
