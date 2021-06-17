using DeepEqual.Syntax;
using eHub.Common.Api;
using eHub.Common.Models;
using eHub.Common.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHub.Common.Tests
{
    [TestFixture]
    public class PoolServiceTests
    {
        Mock<IWebInterface> _apiMock;

        [SetUp]
        public void Setup()
        {
            _apiMock = new Mock<IWebInterface>();
        }

        [Test]
        public async Task GetAllStatuses_Null_Response()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public async Task GetAllStatuses_Null_Data()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public async Task GetAllStatuses_All_Active()
        {
            // Arrange

            // Act

            // Assert
        }

        IEnumerable<PiPin> GetTestPins(int state)
        {
            yield return new PiPin
            {
                PinNumber = Pin.PoolPump_1,
                State = state  
            };
            yield return new PiPin
            {
                PinNumber = Pin.PoolPump_2,
                State = state  
            };
            yield return new PiPin
            {
                PinNumber = Pin.BoosterPump_1,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = Pin.BoosterPump_2,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = Pin.Heater,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = Pin.PoolLight,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = Pin.SpaLight,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = Pin.GroundLights,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = Pin.SpaPump_1,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = Pin.SpaPump_2,
                State = state
            };
        }
    }
}