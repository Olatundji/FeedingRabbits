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
    public partial class ListVenteViewModel : ObservableObject
    {
        public bool IsLoading { get; set; }
        public ObservableCollection<Vente> VenteList { get; } = new ObservableCollection<Vente>();
        public ObservableCollection<Lapin> LapinList { get; } = new ObservableCollection<Lapin>();

        public readonly IVenteServices _venteServices;

        public ListVenteViewModel(IVenteServices venteServices)
        {
            _venteServices = venteServices;
        }

        [RelayCommand]
        public async Task GetVenteList()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;

                var ventes = await _venteServices.GetVenteList();
                var lapins = await _venteServices.GetLapinList();

                VenteList.Clear();
                LapinList.Clear();

                foreach (var vente in ventes)
                {
                    VenteList.Add(vente);
                }

                foreach (var lapin in lapins)
                {
                    LapinList.Add(lapin);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

    }
}
