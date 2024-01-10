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
    [QueryProperty(nameof(LapinDetail), "LapinDetail")]
    public partial class AddLapinViewModel : ObservableObject
    {
        private readonly ILapinServices _lapinServices;

        public AddLapinViewModel(ILapinServices lapinServices)
        {
            _lapinServices = lapinServices;
        }

        private Lapin _lapinDetail = new Lapin();

        public Lapin LapinDetail
        {
            get => _lapinDetail;
            set => SetProperty(ref _lapinDetail, value);
        }

        private RelayCommand _addUpdateLapinCommand;
        public RelayCommand AddUpdateLapinCommand => _addUpdateLapinCommand ??= new RelayCommand(AddUpdateLapin);

        private async void AddUpdateLapin()
        {
            if (string.IsNullOrEmpty(LapinDetail.Code) ||
                string.IsNullOrEmpty(LapinDetail.CodeParent) ||
                string.IsNullOrEmpty(LapinDetail.Race) ||
                LapinDetail.Poids <= 0 ||
                LapinDetail.Taille <= 0 ||
                string.IsNullOrEmpty(LapinDetail.Sexe) ||
                LapinDetail.Naissance == default(DateTime) ||
                string.IsNullOrEmpty(LapinDetail.Categorie))
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez renseigner toutes les informations du lapin avant d'enregistrer.", "OK");
                return;
            }

            bool response = false;

            if (LapinDetail.Id > 0)
            {
                response = await _lapinServices.UpdateLapin(LapinDetail);
            }
            else
            {
                response = await _lapinServices.AddLapin(new Models.Lapin
                {
                    Code = LapinDetail.Code,
                    CodeParent = LapinDetail.CodeParent,
                    Race = LapinDetail.Race,
                    Poids = LapinDetail.Poids,
                    Taille = LapinDetail.Taille,
                    Sexe = LapinDetail.Sexe,
                    Naissance = LapinDetail.Naissance,
                    Categorie = LapinDetail.Categorie,
                });
            }

            if (response)
            {
                await Shell.Current.DisplayAlert("Infos", "Information de lapin enregistrée", "OK");
                LapinDetail = new Lapin();
                //await Shell.Current.GoToAsync(nameof(ListLapinPage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez réessayer", "OK");
            }
        }
    }
}
