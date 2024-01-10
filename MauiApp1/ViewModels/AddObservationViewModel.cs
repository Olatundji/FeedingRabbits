using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System.Linq;
using MauiApp1.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class AddObservationViewModel : ObservableObject
    {
        private readonly IObservationServices _observationServices;
        private readonly ILapinServices _lapinServices;
        private List<Observation> Observations { get; set; }

        public ObservableCollection<Lapin> LapinList { get; } = new ObservableCollection<Lapin>();

        private Lapin _selectedLapin;
        public Lapin SelectedLapin
        {
            get => _selectedLapin;
            set => SetProperty(ref _selectedLapin, value);
        }

        private string _note;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        private DateTime _dateAjout;
        public DateTime DateAjout
        {
            get => _dateAjout;
            set => SetProperty(ref _dateAjout, value);
        }

        public AsyncRelayCommand AddObservationCommand { get; }

        public AddObservationViewModel(IObservationServices observationServices, ILapinServices lapinServices)
        {
            _observationServices = observationServices;
            _lapinServices = lapinServices;

            AddObservationCommand = new AsyncRelayCommand(AddObservation);

            Observations = new List<Observation>();
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

        private async Task AddObservation()
        {
            try
            {
                if (SelectedLapin == null || string.IsNullOrWhiteSpace(Note) || DateAjout == default)
                {
                    await Shell.Current.DisplayAlert("Alerte", "Veuillez remplir toutes les cases avant d'ajouter l'observation.", "OK");
                    return;
                }

                var observation = new Models.Observation
                {
                    LapinId = SelectedLapin.Id,
                    Note = Note,
                    DateAjout = DateTime.Now
                };

                await _observationServices.AddObservation(observation);

                await Shell.Current.DisplayAlert("Succès", "L'observation a été ajoutée.", "OK");

                // Effacer les valeurs après l'ajout
                SelectedLapin = null;
                Note = string.Empty;
                DateAjout = default;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
            }
        }
    }
}




//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.DependencyInjection;
//using CommunityToolkit.Mvvm.Input;
//using MauiApp1.Models;
//using MauiApp1.Services;
//using Microsoft.Maui.Controls;
//using System;
//using System.Collections.ObjectModel;
//using System.Threading.Tasks;

//namespace MauiApp1.ViewModels
//{
//    public partial class AddObservationViewModel : ObservableObject
//    {
//        private readonly IObservationServices _observationServices;
//        private readonly ILapinServices _lapinServices;

//        public ObservableCollection<Lapin> LapinList { get; } = new ObservableCollection<Lapin>();

//        private Lapin _selectedLapin;
//        public Lapin SelectedLapin
//        {
//            get => _selectedLapin;
//            set => SetProperty(ref _selectedLapin, value);
//        }

//        private string _note;
//        public string Note
//        {
//            get => _note;
//            set => SetProperty(ref _note, value);
//        }

//        private DateTime _dateajout;
//        public DateTime DateAjout
//        {
//            get => _dateajout;
//            set => SetProperty(ref _dateajout, value);
//        }


//        public AsyncRelayCommand AddObservationCommand { get; }

//        public AddObservationViewModel(IObservationServices observationServices, ILapinServices lapinServices)
//        {
//            _observationServices = observationServices;
//            _lapinServices = lapinServices;

//            AddObservationCommand = new AsyncRelayCommand(AddObservation);

//            _ = GetLapinList();
//        }

//        private async Task GetLapinList()
//        {
//            try
//            {
//                var lapins = await _lapinServices.GetLapinList();
//                LapinList.Clear();
//                foreach (var lapin in lapins)
//                {
//                    LapinList.Add(lapin);
//                }
//            }
//            catch (Exception ex)
//            {
//                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
//            }
//        }

//        private async Task AddObservation()
//        {
//            try
//            {
//                var observation = new Models.Observation
//                {
//                    LapinId = SelectedLapin.Id,
//                    Note = Note,
//                    DateAjout = DateTime.Now
//                };

//                await _observationServices.AddObservation(observation);

//                await Shell.Current.DisplayAlert("Succès", "L'observation a été ajoutée.", "OK");

//            }
//            catch (Exception ex)
//            {
//                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");

//            }
//        }
//    }
//}
