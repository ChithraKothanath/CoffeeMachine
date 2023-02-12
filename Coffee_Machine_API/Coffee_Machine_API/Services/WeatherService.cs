using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Coffee_Machine_API.Services
{
    public class WeatherService : IWeatherService
    {
        private HttpClient _httpClient;
        public WeatherService(IHttpClientFactory httpClientFactory) 
        {
            this._httpClient = httpClientFactory.CreateClient();
            this._httpClient.BaseAddress = new Uri("http://api.openweathermap.org");

        }
        public async Task<decimal> GetTemperature()
        {
           
            var response = await this._httpClient.GetAsync($"/data/2.5/weather?q=Sydney&appid=7f6f3b03ff3f3e69cbaaf69ac4bafade&units=metric");
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();

            var jobject = (JObject)JsonConvert.DeserializeObject(stringResult);
            var jvalue = (JValue)jobject["main"]["temp"];

            return (decimal)jvalue;
        }

        
    }
}
