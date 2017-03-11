using NUnit.Framework;

namespace Wanderlust.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(false);
        }

        [Test]
        public void Test2()
        {
            Assert.IsFalse(false);
        }
    }
}
