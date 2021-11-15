public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Weather Weather { get; set; }
}

public class Weather
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
}

namespace Gql {
    public class Query
    {
        public City GetCity() =>
            new City
            {
                Id = 1,
                Name = "London",
                Weather = new Weather
                {
                    Temperature = 10,
                    Humidity = 20
                }
            };
    }
}