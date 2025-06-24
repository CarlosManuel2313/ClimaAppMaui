using ClimaAppMaui.Models;
using ClimaAppMaui.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace ClimaAppMaui.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly WeatherService _service = new();

    // Hacer nullable porque inicialmente no tiene valor
    private WeatherInfo? _weather;

    public WeatherInfo? Weather
    {
        get => _weather;
        set
        {
            _weather = value;
            OnPropertyChanged();
        }
    }

    public string Ciudad { get; set; } = "Santo Domingo";

    public Command BuscarClimaCommand { get; }

    public MainViewModel()
    {
        BuscarClimaCommand = new Command(async () => await GetWeather());
    }

    private async Task GetWeather()
    {
        var clima = await _service.GetWeatherAsync(Ciudad);
        Weather = clima;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
