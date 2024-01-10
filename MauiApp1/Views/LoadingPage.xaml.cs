using MauiApp1.Services;

namespace MauiApp1.Views;

public partial class LoadingPage : ContentPage
{
    private readonly AuthServices _authServices;

    public LoadingPage(AuthServices authServices)
    {
        InitializeComponent();
        _authServices = authServices;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authServices.IsAuthenticatedAsync())
        {
            // User is logged in
            // redirect to main page
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            // User is not logged in 
            // Redirect to LoginPage
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}