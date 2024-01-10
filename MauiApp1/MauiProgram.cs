using MauiApp1.Services;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//Services
		builder.Services.AddTransient<AuthServices>();
		builder.Services.AddSingleton<IHomeServices, HomeServices>();
		builder.Services.AddSingleton<IUserServices, UserServices>();
        builder.Services.AddSingleton<ILapinServices, LapinServices>();
		builder.Services.AddSingleton<IUpdateLapinServices, UpdateLapinServices>();
		builder.Services.AddSingleton<IAlimentServices, AlimentServices>();
		builder.Services.AddSingleton<IObservationServices, ObservationServices>();
		builder.Services.AddSingleton<ITypeServices, TypeServices>();
		builder.Services.AddScoped<IAlimentationServices, AlimentationServices>();
		builder.Services.AddSingleton<IVenteServices, VenteServices>();

		//Views
		builder.Services.AddTransient<LoadingPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ListUtilisateurPage>();
        builder.Services.AddTransient<AddLapinPage>();
        builder.Services.AddSingleton<UpdateLapinPage>();
        builder.Services.AddSingleton<ListLapinPage>();
        builder.Services.AddSingleton<AddAlimentPage>();
        builder.Services.AddSingleton<ListAlimentPage>();
        builder.Services.AddSingleton<AddObsPage>();
        builder.Services.AddSingleton<ListObsPage>();
        builder.Services.AddSingleton<AddTypePage>();
        builder.Services.AddSingleton<ListTypePage>();
        builder.Services.AddSingleton<AlimentationPage>();
        builder.Services.AddSingleton<VentePage>();
        builder.Services.AddSingleton<ListVentePage>();

        //ViewModels
        builder.Services.AddSingleton<SignUpViewModel>();		
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<ListUtilisateurViewModel>();
		builder.Services.AddSingleton<AddLapinViewModel>();
		builder.Services.AddSingleton<UpdateLapinViewModel>();
		builder.Services.AddSingleton<ListLapinViewModel>();
        builder.Services.AddSingleton<AddAlimentViewModel>();
        builder.Services.AddSingleton<ListAlimentViewModel>();
        builder.Services.AddSingleton<AddObservationViewModel>();
        builder.Services.AddSingleton<ListObservationViewModel>();
        builder.Services.AddSingleton<AddTypeViewModel>();
        builder.Services.AddSingleton<ListTypeViewModel>();
        builder.Services.AddSingleton<AlimentationViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<VenteViewModel>();
        builder.Services.AddSingleton<ListVenteViewModel>();


        return builder.Build();
	}
}
