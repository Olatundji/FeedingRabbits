using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddTypePage : ContentPage
{
	public AddTypePage(AddTypeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;	
	}
}