using System.Text.Json.Serialization;
namespace WeatherApp.Models
{
    public class OpenWeatherMapResponse
    {
        [JsonPropertyName("coord")]
        public CoordModel Coord { get; set; } = new();

        [JsonPropertyName("weather")]
        public List<WeatherConditionModel> Weather { get; set; } = new();

        [JsonPropertyName("main")]
        public MainModel Main { get; set; } = new();

        [JsonPropertyName("wind")]
        public WindModel Wind { get; set; } = new();

        [JsonPropertyName("sys")]
        public SysModel Sys { get; set; } = new();

        [JsonPropertyName("name")]
        public string CityName { get; set; } = string.Empty;

        [JsonPropertyName("cod")]
        public int Code { get; set; }
    }

    public class CoordModel
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }

    public class WeatherConditionModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }

    public class MainModel
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WindModel
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }
    }

    public class SysModel
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }
}
