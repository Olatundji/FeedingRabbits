using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class AddTypeViewModel : ObservableObject
    {
        private readonly ITypeServices _typeServices;
        public AddTypeViewModel(ITypeServices typeServices)
        {
            _typeServices = typeServices;
        }

        [ObservableProperty]

        private string nom;

        [RelayCommand]
        public async void AddUpdateLapinType()
        {
            var lapinType = new LapinType
            {
                Nom = nom,
            };

            var response = await _typeServices.AddType(lapinType);
            if (response)
            {
                await Shell.Current.DisplayAlert("Infos", "Type de lapin enregistré", "OK");
                //await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez réessayer", "OK");
            }
        }
    }
}
