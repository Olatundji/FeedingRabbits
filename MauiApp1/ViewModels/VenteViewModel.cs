using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class VenteViewModel : ObservableObject
    {
        public readonly IVenteServices _venteServices;
        private readonly ILapinServices _lapinServices;

        private List<Vente> Ventes { get; set; }

        public ObservableCollection<Lapin> LapinList { get; } = new ObservableCollection<Lapin>();

        private Lapin _selectedLapin;
        public Lapin SelectedLapin
        {
            get => _selectedLapin;
            set => SetProperty(ref _selectedLapin, value);
        }

        private DateTime _dateVente;
        public DateTime DateVente
        {
            get => _dateVente;
            set => SetProperty(ref _dateVente, value);
        }

        private double _prix;
        public double Prix
        {
            get => _prix;
            set => SetProperty(ref _prix, value);
        }

        public AsyncRelayCommand AddVenteCommand { get; }
        public VenteViewModel(IVenteServices venteServices, ILapinServices lapinServices)
        {
            _venteServices = venteServices;
            _lapinServices = lapinServices;

            AddVenteCommand = new AsyncRelayCommand(AddVente);

            Ventes = new List<Vente>();
            _ = GetLapinList();
        }


        private async Task GetLapinList()
        {
            try
            {
                var lapins = await _lapinServices.GetLapinList();
                LapinList.Clear();
                foreach (var lapin in lapins)
                {
                    LapinList.Add(lapin);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
            }
        }

        private async Task AddVente()
        {
            try
            {
                if (SelectedLapin == null || DateVente == default ||  Prix <= 0)
                {
                    await Shell.Current.DisplayAlert("Alerte", "Veuillez renseigner toutes les informations d'observation avant d'enregistrer.", "OK");
                    return;
                }

                var vente = new Models.Vente
                {
                    LapinId = SelectedLapin.Id,
                    DateVente = DateVente, //DateTime.Now,
                    Prix = Prix
                };

                await _venteServices.AddVente(vente);

                await Shell.Current.DisplayAlert("Succès", "L'information sur la vente a été ajoutée.", "OK");

                // Effacer les valeurs après l'ajout
                SelectedLapin = null;
                DateVente = default;
                Prix = 0;

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
            }
        }
    }
}
