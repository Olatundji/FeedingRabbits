using System.Collections.ObjectModel;
using System.ComponentModel;
using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1.ViewModels
{   
    public class HomeViewModel : INotifyPropertyChanged
    {
        //private readonly ILapinServices _lapinServices;
        private readonly IHomeServices _homeServices;

        public ObservableCollection<Lapin> LapinList { get; } = new ObservableCollection<Lapin>();
        //public ILapinServices LapinServices => _lapinServices;


        private double _mortalityRate;
        public double MortalityRate
        {
            get => _mortalityRate;
            set
            {
                _mortalityRate = value;
                OnPropertyChanged(nameof(MortalityRate));
            }
        }

        private int _maladeLapinsCount;
        public int MaladeLapinsCount
        {
            get => _maladeLapinsCount;
            set
            {
                _maladeLapinsCount = value;
                OnPropertyChanged(nameof(MaladeLapinsCount));
            }
        }

        public HomeViewModel(IHomeServices homeServices) //, ILapinServices lapinServices
        {
            //_lapinServices = lapinServices;
            _homeServices = homeServices;
            LoadData();
        }

        public void LoadData()
        {
            // Obtenir les données des lapins depuis le service
            var lapins = _homeServices.GetLapins();

            // Ajouter les lapins à la collection
            if (lapins != null && lapins.Any())
            {
                // Ajouter les lapins à la collection
                foreach (var lapin in lapins)
                {
                    LapinList.Add(lapin);
                }

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LapinList)));
                // Calculer les statistiques
                CalculerTauxMortaliter();
                CountLapinsMalade();
            }
            else
            {
                // Afficher un message indiquant qu'aucun lapin n'est enregistré
                 Shell.Current.DisplayAlert("Infos", "Aucun lapin n'est enregistré, Veuillez enrégistrez les informations relatives aux lapins.", "OK");
            }
        }

        public void AjouterLapin(Lapin lapin)
        {
            LapinList.Add(lapin);
            CalculerTauxMortaliter();
            CountLapinsMalade();
        }
        private void CalculerTauxMortaliter()
        {
            int totalLapins = LapinList.Count;
            int deceasedLapins = LapinList.Count(lapin => lapin.Deces);

            double mortalityRate = (double)deceasedLapins / totalLapins * 100;
            MortalityRate = Math.Round(mortalityRate, 2);
        }

        private void CountLapinsMalade()
        {
            MaladeLapinsCount = LapinList.Count(lapin => lapin.Malade);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}