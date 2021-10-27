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

namespace WeatherApp.Tests
{
    public class OpenWeatherMapServiceTests
    {
        [Fact]
        public async Task GetWeatherByLocationAsync_GivenValidLocation_ReturnsSuccessfulResults()
        {
            ////Arrange
            //var mockHttpClient = new Mock<HttpClient>();
            //mockHttpClient.Setup(_ => _.SendAsync(
            //        It.IsAny<HttpRequestMessage>(),
            //        It.IsAny<CancellationToken>()
            //    )).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));
                

            //var mockHttpClientFactory = new Mock<IHttpClientFactory>("OpenWeatherMapV2.5");
            //mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(mockHttpClient.Object);

            //var openWeatherMapService = new OpenWeatherMapService(mockHttpClientFactory.Object);

            ////Act
            //var response = await openWeatherMapService.GetWeatherByLocationAsync("Cambridge, GB");

            ////Assert
            //response.Should().NotBeNull();

        }

        [Fact]
        public void GetWeatherByLocationAsync_GivenAnInvalidLocation_ThrowsException()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
