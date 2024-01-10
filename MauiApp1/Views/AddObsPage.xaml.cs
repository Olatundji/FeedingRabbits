using MauiApp1.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiApp1.Views
{
    public partial class AddObsPage : ContentPage
    {
        public AddObsPage(AddObservationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
