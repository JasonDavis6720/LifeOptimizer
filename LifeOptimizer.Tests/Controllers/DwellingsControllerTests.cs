using LifeOptimizer.Server.Controllers;
using LifeOptimizer.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LifeOptimizer.Tests.Controllers
{
    public class DwellingsControllerTests
    {
        private readonly Mock<IDwellingService> _mockDwellingService;
        private readonly DwellingsController _controller;

        public DwellingsControllerTests()
        {
            _mockDwellingService = new Mock<IDwellingService>();
            _controller = new DwellingsController(_mockDwellingService.Object);
        }

        [Fact]
        public async Task GetDwellingByIdAsync_ReturnsOk_WhenDwellingExists()
        {
            // Arrange
            var dwellingId = 1;
            var dwellingResponse = new DwellingResponseDto { Id = dwellingId };
            _mockDwellingService.Setup(s => s.GetDwellingResponseByIdAsync(dwellingId))
                .ReturnsAsync(dwellingResponse);

            // Act
            var result = await _controller.GetDwellingByIdAsync(dwellingId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(dwellingResponse, okResult.Value);
        }

        [Fact]
        public async Task GetDwellingByIdAsync_ReturnsNotFound_WhenDwellingDoesNotExist()
        {
            // Arrange
            var dwellingId = 1;
            _mockDwellingService.Setup(s => s.GetDwellingResponseByIdAsync(dwellingId))
                .ReturnsAsync((DwellingResponseDto)null);

            // Act
            var result = await _controller.GetDwellingByIdAsync(dwellingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateDwellingForUserAsync_ReturnsCreatedAtAction_WhenSuccessful()
        {
            // Arrange
            var userId = "user123";
            var dwellingRequest = new DwellingRequestDto();
            var dwellingResponse = new DwellingResponseDto { Id = 1 };
            _mockDwellingService.Setup(s => s.CreateDwellingForUserAsync(userId, dwellingRequest))
                .ReturnsAsync(dwellingResponse);

            // Act
            var result = await _controller.CreateDwellingForUserAsync(userId, dwellingRequest);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(DwellingsController.GetDwellingByIdAsync), createdAtActionResult.ActionName);
            Assert.Equal(dwellingResponse, createdAtActionResult.Value);
        }

        [Fact]
        public async Task CreateDwellingForUserAsync_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var userId = "user123";
            var dwellingRequest = new DwellingRequestDto();
            _controller.ModelState.AddModelError("Error", "Invalid model");

            // Act
            var result = await _controller.CreateDwellingForUserAsync(userId, dwellingRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateDwellingForUserAsync_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var userId = "user123";
            var dwellingRequest = new DwellingRequestDto();
            _mockDwellingService.Setup(s => s.CreateDwellingForUserAsync(userId, dwellingRequest))
                .ThrowsAsync(new InvalidOperationException("Error"));

            // Act
            var result = await _controller.CreateDwellingForUserAsync(userId, dwellingRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error", ((dynamic)badRequestResult.Value).message);
        }

        [Fact]
        public async Task DeleteDwellingByIdAsync_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            var dwellingId = 1;
            _mockDwellingService.Setup(s => s.DeleteDwellingByIdAsync(dwellingId))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteDwellingByIdAsync(dwellingId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteDwellingByIdAsync_ReturnsNotFound_WhenDwellingDoesNotExist()
        {
            // Arrange
            var dwellingId = 1;
            _mockDwellingService.Setup(s => s.DeleteDwellingByIdAsync(dwellingId))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteDwellingByIdAsync(dwellingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
