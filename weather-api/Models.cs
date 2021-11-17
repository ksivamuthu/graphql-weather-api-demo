using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class City
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }

    public async Task<Weather> GetWeather([Parent] City city, [Service] OpenWeatherService weatherService)
    {
        var weather = await weatherService.GetWeather(city.Name);
        return new Weather
        {
           Temperature = weather.Main.Temp,
           Humidity = weather.Main.Humidity,
        }; 
    }
}

public class Weather
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
}

namespace Gql {
    public class Query
    {
        public IQueryable<City> GetCities([Service] CityDbContext dbContext) => dbContext.Cities; 
        public City GetCity([Service] CityDbContext dbContext, int id) => dbContext.Cities.Find(id);
    }
}