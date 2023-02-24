using Microsoft.AspNetCore.Mvc;
using NetCore_CoverletReport_VS2022.Infra;

namespace NetCore_CoverletReport_VS2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherForecastRepository repository;
        public WeatherForecastController(IWeatherForecastRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() => repository.WeatherForecasts;

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            if (id == 0)
                return BadRequest("The Id is required.");

            WeatherForecast r = repository[id];

            if (r is null)
                return NotFound();

            return Ok(r);
        }

        [HttpPost]
        public WeatherForecast Post([FromBody] WeatherForecast res) =>
        repository.AddWeatherForecast(new WeatherForecast
        {
            Summary = res.Summary,
            Date = res.Date,
            TemperatureC = res.TemperatureC, 
            Id = res.Id,
        });

        [HttpPut]
        public WeatherForecast Put([FromBody] WeatherForecast res) => repository.UpdateWeatherForecast(res);

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteWeatherForecast(id);
    }
}