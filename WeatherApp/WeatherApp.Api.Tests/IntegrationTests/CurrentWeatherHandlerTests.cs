using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using WeatherApp.Adapters.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Api.Models;

namespace WeatherApp.Api.Tests.IntegrationTests
{
    public class CurrentWeatherHandlerTests
    {
        private readonly ILogger _logger;
        private readonly CurrentWeatherHandler _currentWeatherHandler;

        public CurrentWeatherHandlerTests()
        {
            Environment.SetEnvironmentVariable("WeatherApi.OpenWeatherMap.ApiKey", "c55cf32ee34fde0d2f8bd8556b99a694");
            Environment.SetEnvironmentVariable("WeatherApi.OpenWeatherMap.BaseUrl", "https://api.openweathermap.org/data/2.5");
            var startup = new Startup();
            var host = new HostBuilder().ConfigureWebJobs(startup.Configure).Build();

            _logger = (ILogger)host.Services.GetService(typeof(ILogger));
            _currentWeatherHandler = new CurrentWeatherHandler((IWeatherServiceAdapter)host.Services.GetService(typeof(IWeatherServiceAdapter)));
        }

        [Fact]
        public async Task CurrentWeatherHandler_GivenValidLocation_ReturnsSuccessfulResults()
        {
            //Arrange
            var httpContext = new DefaultHttpContext();
            var httpRequest = httpContext.Request;
            httpRequest.QueryString = new QueryString("?location=Cambridge, GB");

            //Act
            var response = await _currentWeatherHandler.Run(httpRequest, _logger);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task CurrentWeatherHandler_GivenInvalidLocation_ReturnsBadResponse()
        {
            //Arrange
            var httpContext = new DefaultHttpContext();
            var httpRequest = httpContext.Request;
            httpRequest.QueryString = new QueryString("?location=asasasasasassaddsdfdsa");

            //Act
            var response = await _currentWeatherHandler.Run(httpRequest, _logger);

            //Assert
            response.Should().BeOfType<BadRequestObjectResult>();
            var responseContent = (response as BadRequestObjectResult).Value;
            (responseContent as ErrorDetails).Message.Should().Be("city not found");
        }

        [Fact]
        public async Task CurrentWeatherHandler_GivenNoLocation_ReturnsBadResponse()
        {
            //Arrange
            var httpContext = new DefaultHttpContext();
            var httpRequest = httpContext.Request;
            httpRequest.QueryString = new QueryString("?something=else");

            //Act 
            var response = await _currentWeatherHandler.Run(httpRequest, _logger);

            //Assert
            response.Should().BeOfType<BadRequestObjectResult>();
            var responseContent = (response as BadRequestObjectResult).Value;
            responseContent.Should().Be("Mandatory 'location' querystring parameter is missing.");
        }
    }
}
