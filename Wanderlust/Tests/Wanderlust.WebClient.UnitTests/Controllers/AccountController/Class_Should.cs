using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace Wanderlust.WebClient.UnitTests.Controllers.AccountController
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void HaveAuthorizeAttribute()
        {
            var attr = Attribute.GetCustomAttribute(typeof(WebClient.Controllers.AccountController), typeof(AuthorizeAttribute));

            Assert.IsNotNull(attr);
        }
    }
}
