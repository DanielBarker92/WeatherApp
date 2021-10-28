using FluentAssertions;
using System;
using WeatherApp.Extensions;
using Xunit;

namespace WeatherApp.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void AppendGbCountryCodeIfNotExists_GivenValidSearchString_ReturnsAppendedSearchString()
        {
            //Arrange
            var expectedSearchTerm = "Cambridge, GB";

            //Act
            var result = "Cambridge".AppendGbCountryCodeIfNotExists();

            //Assert
            result.Should().Be(expectedSearchTerm);
        }

        [Fact]
        public void AppendGbCountryCodeIfNotExists_GivenEmptySearchString_ThrowsException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => "".AppendGbCountryCodeIfNotExists());
        }

        [Fact]
        public void AppendGbCountryCodeIfNotExists_GivenNullSearchString_ThrowsException()
        {
            //Arrange
            string searchTerm = null;
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => searchTerm.AppendGbCountryCodeIfNotExists());
        }
    }
}
