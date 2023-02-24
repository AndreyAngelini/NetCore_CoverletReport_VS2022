namespace NetCore_CoverletReport_VS2022.Infra
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private Dictionary<int, WeatherForecast> items;

        public WeatherForecastRepository()
        {
            int seq = 0;
            foreach (var item in Helper.Summaries)
            {
                AddWeatherForecast(new WeatherForecast()
                {
                    Id = seq++,
                    Summary = item,
                    Date = new(),
                    TemperatureC = Random.Shared.Next(-20, 55),
                });
            }
        }

        public WeatherForecast this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<WeatherForecast> WeatherForecasts => items.Values;

        public WeatherForecast AddWeatherForecast(WeatherForecast WeatherForecast)
        {
            if (WeatherForecast.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                WeatherForecast.Id = key;
            }
            items[WeatherForecast.Id] = WeatherForecast;
            return WeatherForecast;
        }
        public void DeleteWeatherForecast(int id) => items.Remove(id);

        public WeatherForecast UpdateWeatherForecast(WeatherForecast WeatherForecast) => AddWeatherForecast(WeatherForecast);
    }
}
