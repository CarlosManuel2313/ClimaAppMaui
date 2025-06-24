using ClimaAppMaui.Models;
using Microsoft.Maui.Controls;

namespace ClimaAppMaui.Views;

public partial class DetallePage : ContentPage
{
    public DetallePage(WeatherInfo info)
    {
        InitializeComponent();
        BindingContext = info;
    }
}
