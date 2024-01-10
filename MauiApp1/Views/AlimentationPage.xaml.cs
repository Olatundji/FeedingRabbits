using Microsoft.Maui.Controls;
using MauiApp1.ViewModels;
using MauiApp1.Services; // Ajout de la référence au namespace du service

namespace MauiApp1.Views
{
    public partial class AlimentationPage : ContentPage
    {
        private readonly IAlimentationServices _alimentationServices;
        private AlimentationViewModel _viewModel;

        public AlimentationPage(IAlimentationServices alimentationServices)
        {
            _alimentationServices = alimentationServices;
            _viewModel = new AlimentationViewModel(_alimentationServices);

            InitializeComponent();

            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Récupérer l'instance d'AlimentationViewModel à partir du contexte de liaison
            _viewModel = (AlimentationViewModel)BindingContext;

            // S'abonner à l'événement DataUpdated
            _viewModel.DataUpdated += ViewModel_DataUpdated;

            // Charger les données initiales
            _ = LoadData();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Se désabonner de l'événement DataUpdated
            _viewModel.DataUpdated -= ViewModel_DataUpdated;
        }

        private async void ViewModel_DataUpdated(object sender, DataUpdatedEventArgs e)
        {
            // Charger les données lorsque l'événement DataUpdated est déclenché
            await LoadData();
        }

        private async Task LoadData()
        {
            // Charger les données de la page Alimentation
            await _viewModel.LoadData();
        }

        //public async void LoadData()
        //{
        //    await _viewModel.LoadData();
        //}
    }

}
