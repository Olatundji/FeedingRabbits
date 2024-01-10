using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ListTypePage : ContentPage
{
	private ListTypeViewModel _listTypeViewModel;
    public ListTypePage(ListTypeViewModel viewModel)
    {
        InitializeComponent();
        _listTypeViewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _listTypeViewModel.GetLapinTypeListCommand.Execute(null);
    }
}