using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class ListLapinViewModel : ObservableObject
    {
        public bool IsLoading { get; set; }
        public ObservableCollection<Lapin> LapinList { get; set; } = new ObservableCollection<Lapin>();
        private readonly ILapinServices _lapinServices;

        public ListLapinViewModel(ILapinServices lapinServices)
        {
            _lapinServices = lapinServices;
        }

        [RelayCommand]
        public async void GetLapinList()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;
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
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        public async Task CreateLapin()
        {
            await Shell.Current.GoToAsync(nameof(AddLapinPage));
        }


        //[RelayCommand]
        //public async Task GetLapinList()
        //{

        //    var lapins = await _lapinServices.GetLapinList();
        //    if (lapins?.Count > 0)
        //    {
        //        LapinList.Clear();
        //        foreach (var lapin in lapins)
        //        {
        //            LapinList.Add(lapin);
        //        }
        //    }
        //}


        [RelayCommand]
        public async void EditLapin(Lapin lapin)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("LapinDetail", lapin);
            await Shell.Current.GoToAsync($"{nameof(AddLapinPage)}", navParam);

        }

        //[RelayCommand]
        //public async Task DisplayAction(Lapin lapin)
        //{
        //    var response = await Shell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

        //    if (response == "Edit")
        //    {
        //        var navParams = new Dictionary<string, object>();
        //        navParams.Add("LapinDetail", lapin);
        //        await Shell.Current.GoToAsync($"{nameof(AddLapinPage)}", navParams);
        //    }
        //    if (response == "Delete")
        //    {
        //        var deletresponse = await _lapinServices.DeleteLapin(lapin);

        //        if (LapinList.Any() == true)
        //        {
        //            GetLapinList();
        //        }
        //    }
        //}
        //[RelayCommand]
        //public async void DeleteUser(User user)
        //{
        //    var delResponse = await _studentService.DeleteUser(user);
        //    if (LapinList.Any() == true)
        //        {
        //            await GetUserList();
        //        }
        //}

        ////public async void LoadLapin(string lapinId)
        ////{
        ////    var lapin = await _lapinServices.GetLapin(lapinId);

        ////    if (lapin != null)
        ////    {
        ////        Lapin = lapin;
        ////    }
        ////}
    }
}
