using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class UpdateLapinPage : ContentPage
{
	public UpdateLapinPage(UpdateLapinViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}