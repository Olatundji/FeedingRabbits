using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace MauiApp1.ViewModels
{
    public partial class ListUtilisateurViewModel : ObservableObject
    {
        private readonly IUserServices _userServices;

        public ObservableCollection<User> UserList { get; } = new ObservableCollection<User>();

       
        public ListUtilisateurViewModel(IUserServices userServices)
        {
            _userServices = userServices;
            GetUserList();
        }

        private async void GetUserList()
        {
            try
            {
                var users = await _userServices.GetUserList();
                UserList.Clear();
                foreach (var user in users)
                {
                    UserList.Add(user);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async void RemoveUser(User user)
        {
            var delResponse = await _userServices.DeleteUser(user);
            if (UserList.Any() == true)
            {
                GetUserList();
            }
        }


        //public RelayCommand<User> DeleteUserCommand => new RelayCommand<User>(async (user) =>
        //{
        //    bool result = await Shell.Current.DisplayAlert("Confirmation", $"Voulez-vous supprimer?", "Oui", "Non");
        //    if (result)
        //    {
        //        try
        //        {
        //            await _userServices.DeleteUser(user);
        //            UserList.Remove(user);
        //        }
        //        catch (Exception ex)
        //        {
        //            await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
        //        }
        //    }
        //});

    }
}





























//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using MauiApp1.Models;
//using MauiApp1.Services;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MauiApp1.ViewModels
//{
//    public partial class ListUtilisateurViewModel : ObservableObject
//    {
//        private readonly IUserServices _userServices;

//        public ListUtilisateurViewModel(IUserServices userServices)
//        {
//            _userServices = userServices;
//            GetUserList();
//        }

//        private async void GetUserList()
//        {
//            try
//            {
//                var users = await _userServices.GetUserList();
//                UserList = new ObservableCollection<User>(users);
//            }
//            catch (Exception ex)
//            {
//                await Shell.Current.DisplayAlert("Alerte", ex.Message, "OK");
//            }
//        }

//        public ObservableCollection<User> UserList
//        {
//            get => _userList;
//            set => SetProperty(ref _userList, value);
//        }

//        private ObservableCollection<User> _userList;
//    }
//}
