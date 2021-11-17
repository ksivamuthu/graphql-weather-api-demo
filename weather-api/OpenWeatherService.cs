using Newtonsoft.Json;

public class OpenWeatherService
{
    private readonly string _apiKey = Environment.GetEnvironmentVariable("OPEN_WEATHER_API_KEY");
    private readonly HttpClient _httpClient;
    public OpenWeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
    }

    public async Task<OpenWeatherResponse> GetWeather(string city)
    {
        var response = await _httpClient.GetAsync($"weather?q={city}&appid={_apiKey}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OpenWeatherResponse>(content);
    }

    public class OpenWeatherResponse
    {
        public string Name { get; set; }

        public IEnumerable<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }

        public float Humidity { get; set; }
    }
}