using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class ListAlimentViewModel : ObservableObject
    {
        public bool IsLoading { get; set; }
        public ObservableCollection<Aliment> AlimentList { get; } = new ObservableCollection<Aliment>();
        
        private readonly IAlimentServices _alimentServices;

        public ListAlimentViewModel(IAlimentServices alimentServices)
        {
            _alimentServices = alimentServices;
        }

        [RelayCommand]
        public async void GetAlimentList()
        {
            if (IsLoading)
            {
                return;
            }
            try
            {
                var aliments = await _alimentServices.GetAlimentList();
                AlimentList.Clear();
                foreach (var aliment in aliments)
                {
                    AlimentList.Add(aliment);
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

        [RelayCommand]
        public async Task CreateAliment()
        {
            await Shell.Current.GoToAsync(nameof(AddAlimentPage));
        }

        [RelayCommand]
        public async Task DisplayAction(Aliment aliment)
        {
            var response = await Shell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

            if (response == "Edit")
            {
                var navParams = new Dictionary<string, object>
                {
                    { "AlimentDetail", aliment }
                };
                await Shell.Current.GoToAsync(nameof(AddAlimentPage), navParams);
            }
            if (response == "Delete")
            {
                var deletresponse = await _alimentServices.DeleteAliment(aliment);

                if (AlimentList.Any() == true)
                {      
                    GetAlimentList();
                }
            }
        }
    }
}
