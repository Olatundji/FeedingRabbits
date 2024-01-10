using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    //private async void Button_Clicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushModalAsync(new SignUpPage());
    //}


    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
}

