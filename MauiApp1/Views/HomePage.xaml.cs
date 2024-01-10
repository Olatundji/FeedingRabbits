using MauiApp1.ViewModels;
using MauiApp1.Services;
namespace MauiApp1.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
        //viewModel.LapinServices.DataUpdated += LapinServices_DataUpdated;

        BindingContext = viewModel;
    }

    //private void LapinServices_DataUpdated(object sender, DataUpdatedEventArgs e)
    //{
    //    // Mettez à jour les données du ViewModel
    //    ((HomeViewModel)BindingContext).LoadData();
    //}
}