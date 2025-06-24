using ClimaAppMaui.Models;
using ClimaAppMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace ClimaAppMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    private async void OnVerDetalleClicked(object sender, EventArgs e)
    {
        if (BindingContext is MainViewModel vm && vm.Weather != null)
        {
            await Navigation.PushAsync(new Views.DetallePage(vm.Weather));
        }
    }
}
