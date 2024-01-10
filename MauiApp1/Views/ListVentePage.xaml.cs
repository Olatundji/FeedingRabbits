using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ListVentePage : ContentPage
{
	private ListVenteViewModel _listVenteViewModel;
	public ListVentePage(ListVenteViewModel viewModel)
	{
		InitializeComponent();
        _listVenteViewModel = viewModel;
        BindingContext = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _listVenteViewModel.GetVenteListCommand.Execute(null);
    }
}