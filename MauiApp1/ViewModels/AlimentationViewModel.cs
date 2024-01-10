using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModels
{
    public class AlimentationViewModel : INotifyPropertyChanged
    {
        private readonly IAlimentationServices _alimentationServices;
        private ObservableCollection<Lapin> _lapins = new ObservableCollection<Lapin>();
        private ObservableCollection<Aliment> _aliments = new ObservableCollection<Aliment>();
        private Lapin _selectedLapin;
        private Aliment _selectedAliment;
        private double _quantiteAliment;
        private double _quantiteEau;
        public event EventHandler<DataUpdatedEventArgs> DataUpdated;

        public ObservableCollection<Lapin> Lapins
        {
            get { return _lapins; }
            set { SetProperty(ref _lapins, value); OnPropertyChanged(nameof(Lapins)); }
        }

        public ObservableCollection<Aliment> Aliments
        {
            get { return _aliments; }
            set { SetProperty(ref _aliments, value); OnPropertyChanged(nameof(Aliments)); }
        }

        public Lapin SelectedLapin
        {
            get { return _selectedLapin; }
            set { SetProperty(ref _selectedLapin, value); }
        }

        public Aliment SelectedAliment
        {
            get { return _selectedAliment; }
            set { SetProperty(ref _selectedAliment, value); }
        }

        public double QuantiteAliment
        {
            get { return _quantiteAliment; }
            set { SetProperty(ref _quantiteAliment, value); }
        }

        public double QuantiteEau
        {
            get { return _quantiteEau; }
            set { SetProperty(ref _quantiteEau, value); }
        }

        public RelayCommand CalculerQuantiteAlimentCommand { get; private set; }

        public AlimentationViewModel(IAlimentationServices alimentationServices)
        {
            _alimentationServices = alimentationServices;

            CalculerQuantiteAlimentCommand = new RelayCommand(CalculerQuantiteAliment);

            _ = LoadData();

            CalculerQuantiteAliment(); // Appeler la méthode ici pour calculer la quantité une fois les données chargées
        }

        public async Task LoadData()
        {
            var lapins = await _alimentationServices.GetAllLapins();
            Lapins.Clear();
            foreach (var lapin in lapins)
            {
                Lapins.Add(lapin);
            }

            var aliments = await _alimentationServices.GetAllAliments();
            Aliments.Clear();
            foreach (var aliment in aliments)
            {
                Aliments.Add(aliment);
            }
        }

        public async void CalculerQuantiteAliment()
        {
            try
            {
                if (SelectedLapin != null && SelectedAliment != null)
                {
                    Lapin lapin = await _alimentationServices.GetLapinById(SelectedLapin.Id);
                    Aliment aliment = Aliments.FirstOrDefault(a => a.Id == SelectedAliment.Id);

                    QuantiteAliment = _alimentationServices.CalculerQuantiteAliment(lapin.Categorie, lapin.Poids, lapin.Naissance, aliment.Nom);
                    QuantiteEau = _alimentationServices.CalculerQuantiteEau(lapin.Categorie, aliment.Nom);
                }
                else
                {
                    QuantiteAliment = 0;
                    QuantiteEau = 0;

                    if (SelectedLapin == null && SelectedAliment == null)
                    {
                        await Shell.Current.DisplayAlert("Infos", "Veuillez renseigner toutes les informations de calcul.", "OK");
                    }
                    else if (SelectedLapin == null)
                    {
                        await Shell.Current.DisplayAlert("Erreur", "Veuillez sélectionner un lapin.", "OK");
                    }
                    else if (SelectedAliment == null)
                    {
                        await Shell.Current.DisplayAlert("Erreur", "Veuillez sélectionner un aliment.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
        }

        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
