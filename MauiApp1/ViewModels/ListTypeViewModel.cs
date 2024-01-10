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
    public partial class ListTypeViewModel : ObservableObject
    {
        public bool IsLoading { get; set; }
        public ObservableCollection<LapinType> TypeList { get; } = new ObservableCollection<LapinType>();

        private readonly ITypeServices _typeServices;

        public ListTypeViewModel(ITypeServices typeServices)
        {
            _typeServices = typeServices;
        }

        [RelayCommand]
        public async void GetLapinTypeList()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;
                var lapintypes = await _typeServices.GetTypeList();
                TypeList.Clear();
                foreach (var lapintype in lapintypes)
                {
                    TypeList.Add(lapintype);
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
        public async void RemoveType(LapinType lapintype)
        {
            var delResponse = await _typeServices.DeleteType(lapintype);
            if (TypeList.Any() == true)
            {
                GetLapinTypeList();
            }
        }
    }
}