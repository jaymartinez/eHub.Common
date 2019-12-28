using eHub.Service.Core.Api;
using Moq;
using NUnit.Framework;

namespace Tests.Core
{
    [TestFixture]
    public class PoolServiceTests
    {
        //IPoolService _poolService;
        Mock<IPoolApi> _poolApiMock;


        [SetUp]
        public void Setup()
        {
            _poolApiMock = new Mock<IPoolApi>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}