using MauiApp1.ViewModels;
using Microsoft.Maui.Controls;
using System;
namespace MauiApp1.Views;

public partial class AddLapinPage : ContentPage
{
    public AddLapinPage(AddLapinViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

    }
    //DatePicker datePicker = new DatePicker
    //{
    //    MinimumDate = new DateTime(2018, 1, 1),
    //    MaximumDate = new DateTime(2018, 12, 31),
    //    Date = new DateTime(2018, 6, 21)
    //};
}




