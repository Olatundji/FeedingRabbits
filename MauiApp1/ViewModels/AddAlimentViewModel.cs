using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    [QueryProperty(nameof(AlimentDetail), "AlimentDetail")]
    public partial class AddAlimentViewModel : ObservableObject
    {
        private readonly IAlimentServices _alimentServices;
        public AddAlimentViewModel(IAlimentServices alimentServices)
        {
            _alimentServices = alimentServices;
        }
        [ObservableProperty]
        private Aliment _alimentDetail = new Aliment();

        [RelayCommand]
        public async Task AddUpdateAliment()
        {
            if (string.IsNullOrWhiteSpace(AlimentDetail.Nom) || AlimentDetail.Prix <= 0)
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez renseigner toutes les informations de l'aliment avant de l'enregistrer", "OK");
                return;
            }

            bool response = false;

            if (AlimentDetail.Id > 0)
            {
                response = await _alimentServices.UpdateAliment(AlimentDetail);
            }
            else
            {
                response = await _alimentServices.AddAliment(new Models.Aliment
                {
                    Nom = AlimentDetail.Nom,
                    Prix = AlimentDetail.Prix,
                });
            }
            if (response)
            {
                await Shell.Current.DisplayAlert("Infos", "Information d'aliment enregistrée", "OK");
                AlimentDetail = new Aliment();
            }
            else
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez réessayer", "OK");
            }
        }
    }
}

