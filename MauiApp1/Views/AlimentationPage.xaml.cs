using Microsoft.Maui.Controls;
using MauiApp1.ViewModels;
using MauiApp1.Services; // Ajout de la r�f�rence au namespace du service

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

            // R�cup�rer l'instance d'AlimentationViewModel � partir du contexte de liaison
            _viewModel = (AlimentationViewModel)BindingContext;

            // S'abonner � l'�v�nement DataUpdated
            _viewModel.DataUpdated += ViewModel_DataUpdated;

            // Charger les donn�es initiales
            _ = LoadData();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Se d�sabonner de l'�v�nement DataUpdated
            _viewModel.DataUpdated -= ViewModel_DataUpdated;
        }

        private async void ViewModel_DataUpdated(object sender, DataUpdatedEventArgs e)
        {
            // Charger les donn�es lorsque l'�v�nement DataUpdated est d�clench�
            await LoadData();
        }

        private async Task LoadData()
        {
            // Charger les donn�es de la page Alimentation
            await _viewModel.LoadData();
        }

        //public async void LoadData()
        //{
        //    await _viewModel.LoadData();
        //}
    }

}
