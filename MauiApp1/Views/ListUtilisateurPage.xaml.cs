using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ListUtilisateurPage : ContentPage
{
	public ListUtilisateurPage(ListUtilisateurViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    
}