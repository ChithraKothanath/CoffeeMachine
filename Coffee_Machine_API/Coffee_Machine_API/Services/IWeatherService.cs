namespace Coffee_Machine_API.Services
{
    public interface IWeatherService
    {
        public Task< decimal> GetTemperature();
    }
}
