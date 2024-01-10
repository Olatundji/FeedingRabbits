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
    public partial class ListObservationViewModel : ObservableObject
    {
        public bool IsLoading { get; set; }
        public ObservableCollection<Observation> ObservationList { get; } = new ObservableCollection<Observation>();

        private readonly IObservationServices _observationServices;

                public ListObservationViewModel(IObservationServices observationServices)
                {
                    _observationServices = observationServices;
                }

                [RelayCommand]
                public  async void GetObservationList()
                {
                    if (IsLoading)
                    {
                        return;
                    }

                    try
                    {
                        IsLoading = true;
                        var observations = await _observationServices.GetObservationList();
                        ObservationList.Clear();
                        foreach (var observation in observations)
                        {
                            ObservationList.Add(observation);
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
        public async void RemoveObservation(Observation observation)
        {
            var delResponse = await _observationServices.DeleteObservation(observation);
            if (ObservationList.Any() == true)
            {
                GetObservationList();
            }
        }

        //        [RelayCommand]
        //        public async Task CreateLapin()
        //        {
        //            await Shell.Current.GoToAsync(nameof(AddLapinPage));
        //        }


        //        //[RelayCommand]
        //        //public async Task GetLapinList()
        //        //{

        //        //    var lapins = await _lapinServices.GetLapinList();
        //        //    if (lapins?.Count > 0)
        //        //    {
        //        //        LapinList.Clear();
        //        //        foreach (var lapin in lapins)
        //        //        {
        //        //            LapinList.Add(lapin);
        //        //        }
        //        //    }
        //        //}


        //        [RelayCommand]
        //        public async void EditLapin(Lapin lapin)
        //        {
        //            var navParam = new Dictionary<string, object>();
        //            navParam.Add("LapinDetail", lapin);
        //            await Shell.Current.GoToAsync($"{nameof(AddLapinPage)}", navParam);

        //        }

        //        //[RelayCommand]
        //        //public async Task DisplayAction(Lapin lapin)
        //        //{
        //        //    var response = await Shell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

        //        //    if (response == "Edit")
        //        //    {
        //        //        var navParams = new Dictionary<string, object>();
        //        //        navParams.Add("LapinDetail", lapin);
        //        //        await Shell.Current.GoToAsync($"{nameof(AddLapinPage)}", navParams);
        //        //    }
        //        //    if (response == "Delete")
        //        //    {
        //        //        var deletresponse = await _lapinServices.DeleteLapin(lapin);

        //        //        if (LapinList.Any() == true)
        //        //        {
        //        //            GetLapinList();
        //        //        }
        //        //    }
        //        //}
        //        //[RelayCommand]
        //        //public async void DeleteUser(User user)
        //        //{
        //        //    var delResponse = await _studentService.DeleteUser(user);
        //        //    if (LapinList.Any() == true)
        //        //        {
        //        //            await GetUserList();
        //        //        }
        //        //}

        //        ////public async void LoadLapin(string lapinId)
        //        ////{
        //        ////    var lapin = await _lapinServices.GetLapin(lapinId);

        //        ////    if (lapin != null)
        //        ////    {
        //        ////        Lapin = lapin;
        //        ////    }
        //        ////}
        //    }
        //}

    }
}


//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using MauiApp1.Models;
//using MauiApp1.Services;
//using Microsoft.Maui.Controls;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MauiApp1.ViewModels
//{
//    public class ListObservationViewModel : ObservableObject
//    {
//        //public bool IsLoading { get; set; }
//        private readonly IObservationServices _observationService;

//        public ObservableCollection<Observation> ObservationList { get; } = new ObservableCollection<Observation>();

//        public AsyncRelayCommand<int> LoadObservationsCommand { get; }

//        public ListObservationViewModel(IObservationServices observationService)
//        {
//            _observationService = observationService;

//            LoadObservationsCommand = new AsyncRelayCommand<int>(LoadObservationsAsync);

//            _ = LoadObservationsAsync(0);
//        }

//        private async Task LoadObservationsAsync(int lapinId)
//        {
//            try
//            {
//                var observations = await _observationService.GetObservationByLapinId(lapinId);
//                ObservationList.Clear();
//                foreach (var observation in observations)
//                {
//                    ObservationList.Add(observation);
//                }
//            }
//            catch (Exception ex)
//            {
//                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
//            }
//        }

//    }
//}

