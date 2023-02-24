
using Moq;
using NetCore_CoverletReport_VS2022;
using NetCore_CoverletReport_VS2022.Controllers;
using NetCore_CoverletReport_VS2022.Infra;

namespace NetCore_CoverletReport_VS2022_xUnitTests
{
    public class WeatherForecastControllerTest 
    {

        [Fact]
        public void Test_GET_AllWeatherForecasts()
        {
            // Arrange
            var mockRepo = new Mock<IWeatherForecastRepository>();
            mockRepo.Setup(repo => repo.WeatherForecasts).Returns(Multiple());
            var controller = new WeatherForecastController(mockRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.Equal(10, model.Count());
        }

        private static IEnumerable<WeatherForecast> Multiple()
        {
            int seq = 0;
            var result = new List<WeatherForecast>();
            foreach (var item in Helper.Summaries)
            {
                result.Add(new WeatherForecast()
                {
                    Id = seq++,
                    Summary = item,
                    Date = new(),
                    TemperatureC = Random.Shared.Next(-20, 55),
                });
            }

            return result;
        }
    }
}
