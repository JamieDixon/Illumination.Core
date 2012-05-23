using Moq;
using NUnit.Framework;

namespace Illumination.Core.Tests
{
    [TestFixture]
    public class CacheTests
    {
        private readonly Mock<Cache> _mockCache = new Mock<Cache>();

        [SetUp]
        public void SetUp()
        {
            _mockCache.CallBase = true; // Partial Mocking. Call the base method for methods not explicitly Setup.
        }

        [TestFixture]
        public class GetMethodTest : CacheTests
        {
            
        }

        [TestFixture]
        public class GetOrStoreMethodTests : CacheTests
        {
            [Test]
            public void ExecutesFuncWhenCacheReturnsNull()
            {
                _mockCache.Setup(m => m.Get(It.IsAny<string>())).Returns(null);
                var output = _mockCache.Object.GetOrStore("foo", () => "Foo", 100);

                Assert.AreEqual("Foo", output);
            }

            [Test]
            public void ReturnsValueFromCacheWithoutExecutingFuncWhenCachReturnsItem()
            {
                _mockCache.Setup(m => m.Get(It.IsAny<string>())).Returns("Foo");

                var output = _mockCache.Object.GetOrStore("foo", () => "Bar", 100);
                Assert.AreEqual("Foo", output); // Assert that cached version is returned
            }
        }

        [TestFixture]
        public class InsertMethodTests : CacheTests
        {
            
        }
    }
}
