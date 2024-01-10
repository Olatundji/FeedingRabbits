using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ListObsPage : ContentPage
{
    private ListObservationViewModel _listObservationViewModel;
    public ListObsPage(ListObservationViewModel viewModel)
    {
        InitializeComponent();
        _listObservationViewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _listObservationViewModel.GetObservationListCommand.Execute(null);
    }
}