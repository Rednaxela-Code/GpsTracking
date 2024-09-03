using Api.Controllers;
using Api.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shared.Models;

namespace Tests
{
    public class GpsControllerTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly GpsController _controller;
        private readonly Mock<ILogger<GpsController>> _logger;

        public GpsControllerTests()
        {
            _logger = new Mock<ILogger<GpsController>>();
            _mockContext = new Mock<ApplicationDbContext>();
            _controller = new GpsController(_logger.Object, _mockContext.Object);
        }

        [Fact]
        public async Task PostGpsPoint_ShouldReturnBadRequest_WhenGpsPointIsNull()
        {
            // Act
            var result = await _controller.PostGpsPoint(null);

            // Assert
            result.Should().BeOfType<ActionResult<GpsPoint>>();
        }

        [Fact]
        public async Task PostGpsPoint_ShouldReturnOk_WhenGpsPointIsValid()
        {
            // Arrange
            var point = new GpsPoint { Latitude = 10.0, Longitude = 20.0, Altitude = 0, SatelliteCount = 10, Timestamp = DateTime.Now };
            _mockContext.Setup(x => x.GpsPoints.Add(It.IsAny<GpsPoint>()));
            _mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _controller.PostGpsPoint(point);

            // Assert
            _mockContext.Verify(x => x.GpsPoints.Add(It.IsAny<GpsPoint>()), Times.Once);
            _mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
            result.Should().BeOfType<OkResult>();
        }
    }
}
