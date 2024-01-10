using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class ListAlimentPage : ContentPage
    {
        private ListAlimentViewModel _listAlimentViewModel;
        public ListAlimentPage(ListAlimentViewModel viewModel)
        {
            InitializeComponent();
            _listAlimentViewModel = viewModel;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _listAlimentViewModel.GetAlimentListCommand.Execute(null);
        }
    }
}