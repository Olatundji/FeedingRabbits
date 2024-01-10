using MauiApp1.Models;
using MauiApp1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiApp1.ViewModels
{
    public partial class UpdateLapinViewModel : ObservableObject
    {
        private readonly IUpdateLapinServices _updateLapinServices;
        private readonly ILapinServices _lapinServices;
        public ObservableCollection<Lapin> LapinList { get; } = new ObservableCollection<Lapin>();

        private Lapin _selectedLapin;
        public Lapin SelectedLapin
        {
            get => _selectedLapin;
            set => SetProperty(ref _selectedLapin, value);
        }
        private bool _malade;
        public bool Malade
        {
            get => _malade;
            set => SetProperty(ref _malade, value);
        }

        private DateTime _vente;
        public DateTime Vente
        {
            get => _vente;
            set => SetProperty(ref _vente, value);
        }

        private bool _deces;
        public bool Deces
        {
            get => _deces;
            set => SetProperty(ref _deces, value);
        }

        public AsyncRelayCommand AddUpdateLapinPlusCommand { get; }

        public UpdateLapinViewModel(IUpdateLapinServices updateLapinServices, ILapinServices lapinServices)
        {
            _updateLapinServices = updateLapinServices;
            _lapinServices = lapinServices;

            AddUpdateLapinPlusCommand = new AsyncRelayCommand(AddLapin);

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

        private async Task AddLapin()
        {
            try
            {
                if (SelectedLapin != null)
                {
                    var existingLapin = await _lapinServices.GetLapinById(SelectedLapin.Id);

                    if (existingLapin != null)
                    {
                        existingLapin.Malade = Malade;
                        existingLapin.Vente = Vente;
                        existingLapin.Deces = Deces;

                        await _updateLapinServices.UpdateLapin(existingLapin);

                        await Shell.Current.DisplayAlert("Succès", "Les informations supplémentaires du lapin ont été mises à jour.", "OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Attention", "Lapin introuvable.", "OK");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Attention", "Aucun lapin sélectionné.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
            }
        }

    }
}
