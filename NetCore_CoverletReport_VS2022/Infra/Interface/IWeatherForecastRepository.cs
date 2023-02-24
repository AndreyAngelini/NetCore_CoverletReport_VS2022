namespace NetCore_CoverletReport_VS2022.Infra
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> WeatherForecasts { get; }
        WeatherForecast this[int id] { get; }
        WeatherForecast AddWeatherForecast(WeatherForecast WeatherForecast);
        WeatherForecast UpdateWeatherForecast(WeatherForecast WeatherForecast);
        void DeleteWeatherForecast(int id);
    }
}
