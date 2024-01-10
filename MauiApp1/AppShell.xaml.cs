using MauiApp1.Views;
using MauiApp1.Services;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        private readonly AuthServices _authServices;

        public AppShell()
        {
            InitializeComponent();
            _authServices = new AuthServices();

            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(ListUtilisateurPage), typeof(ListUtilisateurPage));
            Routing.RegisterRoute(nameof(AddLapinPage), typeof(AddLapinPage));
            Routing.RegisterRoute(nameof(UpdateLapinPage), typeof(UpdateLapinPage));
            Routing.RegisterRoute(nameof(ListLapinPage), typeof(ListLapinPage));
            Routing.RegisterRoute(nameof(AddAlimentPage), typeof(AddAlimentPage));
            Routing.RegisterRoute(nameof(ListAlimentPage), typeof(ListAlimentPage));
            Routing.RegisterRoute(nameof(AddObsPage), typeof(AddObsPage));
            Routing.RegisterRoute(nameof(ListObsPage), typeof(ListObsPage));
            Routing.RegisterRoute(nameof(AddTypePage), typeof(AddTypePage));
            Routing.RegisterRoute(nameof(ListTypePage), typeof(ListTypePage));
            Routing.RegisterRoute(nameof(AlimentationPage), typeof(AlimentationPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(VentePage), typeof(VentePage));
            Routing.RegisterRoute(nameof(ListVentePage), typeof(ListVentePage));
        }

        private void OnLogoutClicked(object sender, System.EventArgs e)
        {
            _authServices.Logout();
            Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
