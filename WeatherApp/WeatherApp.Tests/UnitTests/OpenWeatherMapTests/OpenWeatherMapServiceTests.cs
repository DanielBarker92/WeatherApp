using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using WeatherApp.Services.OpenWeatherMapService;
using FluentAssertions;
using Flurl.Http.Testing;

namespace WeatherApp.Tests
{
    public class OpenWeatherMapServiceTests
    {

        private readonly HttpTest _testHttpClient;

        public OpenWeatherMapServiceTests()
        {
            _testHttpClient = new HttpTest();
        }

        [Fact]
        public async Task GetWeatherByLocationAsync_GivenValidLocation_ReturnsSuccessfulResults()
        {
            //Arrange
            _testHttpClient.RespondWithJson(new
            {
                coord = new {
                    lon = 10.00f,
                    lat = 20.00f
                },
                weather = new[] { new
                {
                    Id = 1,
                    Main = "mainvalue",
                    Description = "description of the mainvalue",
                    Icon = @"\AB"
                }},
                @base = "base",
                name = "CambridgeTest"
            });

            Environment.SetEnvironmentVariable("WeatherApi.OpenWeatherMap.ApiKey", "c55cf32ee34fde0d2f8bd8556b99a694");
            Environment.SetEnvironmentVariable("WeatherApi.OpenWeatherMap.BaseUrl", "https://www.fakebaseurl.test/thisisapath/");

            var openWeatherMapService = new OpenWeatherMapService();

            //Act
            var response = await openWeatherMapService.GetWeatherByLocationAsync("Cambridge, GB");

            //Assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWeatherByLocationAsync_GivenAnInvalidLocation_ThrowsException()
        {
            //Arrange
            _testHttpClient.RespondWithJson(new
            {
                cod = "404",
                message = "city not found"
            }, 404);

            Environment.SetEnvironmentVariable("WeatherApi.OpenWeatherMap.ApiKey", "c55cf32ee34fde0d2f8bd8556b99a694");
            Environment.SetEnvironmentVariable("WeatherApi.OpenWeatherMap.BaseUrl", "https://www.fakebaseurl.test/thisisapath/");

            var openWeatherMapService = new OpenWeatherMapService();

            //Act
            var response = await openWeatherMapService.GetWeatherByLocationAsync("ThisIsntAnActualLocation, GB");

            //Assert
            response.Should().NotBeNull();

        }
    }
}
