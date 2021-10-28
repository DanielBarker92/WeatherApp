using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using WeatherApp.Services.OpenWeatherMapService;
using FluentAssertions;
using Flurl.Http.Testing;
using Flurl.Http;
using WeatherApp.Api.Models;

namespace WeatherApp.Api.Tests
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

            var apiSettings = new ApiSettings("dummyapikey", new Uri("http://www.dummybase.url"));
            var openWeatherMapService = new OpenWeatherMapService(apiSettings);

            //Act
            var response = await openWeatherMapService.GetWeatherByLocationAsync("Cambridge, GB");

            //Assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWeatherByLocationAsync_GivenInvalidLocation_ThrowsException()
        {
            //Arrange
            _testHttpClient.RespondWithJson(new
            {
                cod = "404",
                message = "city not found"
            }, 404);

            var apiSettings = new ApiSettings("dummyapikey", new Uri("http://www.dummybase.url"));
            var openWeatherMapService = new OpenWeatherMapService(apiSettings);

            //Act
            Func<Task> action = async () => await openWeatherMapService.GetWeatherByLocationAsync("ThisIsntAnActualLocation, GB");

            //Assert
            (await action.Should().ThrowAsync<FlurlHttpException>()).WithMessage("city not found");

        }
    }
}
