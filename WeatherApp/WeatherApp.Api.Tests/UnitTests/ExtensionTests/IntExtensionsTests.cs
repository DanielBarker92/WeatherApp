using FluentAssertions;
using System;
using WeatherApp.Api.Core.Extensions;
using Xunit;

namespace WeatherApp.Tests
{
    public class IntExtensionsTests
    {
        [Fact]
        public void UnixTimeStampToDateTime_GivenValidInteger_ReturnsCorrectDateTime()
        {
            //Arrange
            var expectedDateTime = new DateTime(1970, 1, 1, 1, 1, 1, 0, DateTimeKind.Utc);

            //Act
            var result = 3661.UnixTimeStampToDateTime();

            //Assert
            result.Should().Be(expectedDateTime);
        }

        [Fact]
        public void UnixTimeStampToDateTime_Given0_ReturnsCorrectDateTime()
        {
            //Arrange
            var expectedDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            //Act
            var result = 0.UnixTimeStampToDateTime();

            //Assert
            result.Should().Be(expectedDateTime);
        }

        [Fact]
        public void UnixTimeStampToDateTime_GivenNegativeInteger_ReturnsCorrectDateTime()
        {
            //Arrange
            var expectedDateTime = new DateTime(1969, 12, 31, 23, 59, 59, 0, DateTimeKind.Utc);

            //Act
            var result = (-1).UnixTimeStampToDateTime();

            //Assert
            result.Should().Be(expectedDateTime);
        }
    }
}
