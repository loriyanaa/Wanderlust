using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace Wanderlust.WebClient.UnitTests.Areas.Admin.Controllers.ImagesController
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void HaveAuthorizeAttribute()
        {
            var attr = Attribute.GetCustomAttribute(typeof(WebClient.Areas.Admin.Controllers.ImagesController), typeof(AuthorizeAttribute));

            Assert.IsNotNull(attr);
        }
    }
}
