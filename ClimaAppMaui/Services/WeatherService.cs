using ClimaAppMaui.Models;
using Newtonsoft.Json;

namespace ClimaAppMaui.Services;

public class WeatherService
{
    private readonly string apiKey = "b6144b1ec780624fda07037cf5491501";
    private readonly string baseUrl = "https://api.openweathermap.org/data/2.5/weather";

    public async Task<WeatherInfo?> GetWeatherAsync(string city)
    {
        using HttpClient client = new();
        string url = $"{baseUrl}?q={city}&appid={apiKey}&units=metric&lang=es";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var weather = JsonConvert.DeserializeObject<WeatherInfo>(json);

                return weather; // Puede ser null, por eso el tipo es WeatherInfo?
            }
            else
            {
                
                return null;
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error al obtener clima: {ex.Message}");
            return null;
        }
    }
}

