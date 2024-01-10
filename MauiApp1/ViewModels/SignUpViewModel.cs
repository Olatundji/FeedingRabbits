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
    public partial class SignUpViewModel : ObservableObject
    {
        private readonly IUserServices _userServices;
        public SignUpViewModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [ObservableProperty]
        
        private string nom;

        [ObservableProperty]

        private string prenom;

        [ObservableProperty]

        private string login;

        [ObservableProperty]

        private string email;

        [ObservableProperty]

        private string password;

        [ObservableProperty]

        private string confirmPassword;

        [RelayCommand]
        public async void AddUpdateUser()
        {
            var existingUser = await _userServices.GetUser();
            if (existingUser != null)
            {
                await Shell.Current.DisplayAlert("Erreur", "Un utilisateur existe déjà.", "OK");
                return;
            }


            if (string.IsNullOrEmpty(Nom) || string.IsNullOrEmpty(Prenom) || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez renseigner toutes les informations avant de vous inscrire.", "OK");
                return;
            }

            var user = new User
            {
                Nom = Nom,
                Prenom = Prenom,
                Login = Login,
                Email = Email,
                Password = Password
            };

            var response = await _userServices.AddUser(user);
            if (response)
            {
                await Shell.Current.DisplayAlert("Infos", "Utilisateur enregistré", "OK");
                await Shell.Current.GoToAsync(nameof(LoginPage));
                Nom = null;
                Prenom = null;
                Login = null;
                Email = null;
                Password = null;
            }
            else
            { 
                await Shell.Current.DisplayAlert("Erreur", "Veuillez réessayer", "OK");
            }
        }

        [RelayCommand]
        public async void Seconnecter()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}
