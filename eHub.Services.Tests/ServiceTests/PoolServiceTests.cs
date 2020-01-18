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
        Mock<IPoolApi> _poolApiMock;

        [SetUp]
        public void Setup()
        {
            _poolApiMock = new Mock<IPoolApi>();
        }

        [Test]
        public async Task GetAllStatuses_Null_Response()
        {
            // Arrange
            _poolApiMock.Setup(x => x.GetAllStatuses()).ReturnsAsync(default(IEnumerable<PiPin>));
            var poolService = new PoolService(_poolApiMock.Object);

            // Act
            var result = await poolService.GetAllStatuses();

            // Assert
            Assert.That(result, Is.EqualTo(Enumerable.Empty<PiPin>()));
        }

        [Test]
        public async Task GetAllStatuses_Null_Data()
        {
            // Arrange
            _poolApiMock.Setup(x => x.GetAllStatuses()).ReturnsAsync(Enumerable.Empty<PiPin>());
            var poolService = new PoolService(_poolApiMock.Object);

            // Act
            var result = await poolService.GetAllStatuses();

            // Assert
            Assert.That(result, Is.EqualTo(Enumerable.Empty<PiPin>()));
        }

        [Test]
        public async Task GetAllStatuses_All_Active()
        {
            // Arrange
            var testData = GetTestPins(PinState.ON);
            _poolApiMock.Setup(x => x.GetAllStatuses()).ReturnsAsync(testData);
            var poolService = new PoolService(_poolApiMock.Object);

            // Act
            var result = await poolService.GetAllStatuses();

            // Assert
            Assert.That(result, Is.Not.Null);
            result.ShouldDeepEqual(testData);
        }

        IEnumerable<PiPin> GetTestPins(PinState state)
        {
            yield return new PiPin
            {
                PinNumber = EquipmentType.PoolPump,
                State = state  
            };
            yield return new PiPin
            {
                PinNumber = EquipmentType.BoosterPump,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = EquipmentType.Heater,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = EquipmentType.PoolLight,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = EquipmentType.SpaLight,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = EquipmentType.GroundLights,
                State = state
            };
            yield return new PiPin
            {
                PinNumber = EquipmentType.SpaPump,
                State = state
            };
        }
    }
}