using System;
using BlandGroupApi.Controllers;
using BlandGroupApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
	public class UserAgeTests
	{
        [Fact]
        public void CalculateAge_ValidDate_ReturnsCorrectAge()
        {
            // Arrange
            var controller = new UserSettingsController();
            string validBirthDate = "05/11/1982 00:00:00"; 

            // Act
            var result = controller.getUserAge(validBirthDate);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.IsType<UserResponse>(okResult.Value);

            // Check the type and content inside the UserResponse
            var userResponse = (UserResponse)okResult.Value;
            Assert.IsType<string>(userResponse.Age);

            // Adjust the expected value based on the current date
            Assert.Equal("41 years, 8 months, 17 days, 0 hours, 0 minutes, 0 seconds", userResponse.Age);
        }

        [Fact]
        public void CalculateAge_InvalidDate_ReturnsBadRequest()
        {
            // Arrange
            var controller = new UserSettingsController();
            string invalidBirthDate = "invalid date";

            // Act
            var result = controller.getUserAge(invalidBirthDate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.IsType<string>(badRequestResult.Value);
            Assert.Equal("Invalid date format. Please use the format MM/dd/yyyy.", (string)badRequestResult.Value);
        }
    }
}

