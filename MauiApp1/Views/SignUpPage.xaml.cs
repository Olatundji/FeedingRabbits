using MauiApp1.Views;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}    
}