using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class VentePage : ContentPage
{
	public VentePage(VenteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}