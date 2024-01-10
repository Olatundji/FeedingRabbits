using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class ListLapinPage : ContentPage
    {
        private ListLapinViewModel _listLapinViewModel;

        public ListLapinPage(ListLapinViewModel viewModel)
        {
            InitializeComponent();
            _listLapinViewModel = viewModel;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _listLapinViewModel.GetLapinListCommand.Execute(null);
        }
    }
}
