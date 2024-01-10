using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddAlimentPage : ContentPage
{
	public AddAlimentPage(AddAlimentViewModel viewModel)
	{
		InitializeComponent();
        BindingContext= viewModel;
	}
    //private async void Button_Clicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushModalAsync(new MainPage());
    //}
    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
{
    var picker = (Picker)sender;
    if (picker.SelectedItem?.ToString() == "Autres aliments")
    {
        comingSoonLabel.IsVisible = true;
    }
    else
    {
        comingSoonLabel.IsVisible = false;
    }
}

}
