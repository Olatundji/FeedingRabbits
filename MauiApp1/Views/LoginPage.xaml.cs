using MauiApp1.Services;
using MauiApp1.Models;
using SQLite;

namespace MauiApp1.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthServices _authServices;
        private readonly SQLiteAsyncConnection _dbConnection;
        public LoginPage(AuthServices authServices)
        {
            InitializeComponent();
            _authServices = authServices;
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);

            //_dbConnection.CreateTableAsync<User>().Wait();
            // Reste de votre code...
        }
        private async Task<bool> TableExistsAsync(string tableName)
        {
            var tableInfo = await _dbConnection.GetTableInfoAsync(tableName);
            return tableInfo.Any();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            string identifiant = EntryIdentifiant.Text;
            string password = Entrypassword.Text;
            _authServices.Login(identifiant, password);

            var tableExists = await TableExistsAsync("User");
            if (!tableExists)
            {
                await DisplayAlert("Erreur", "Veuillez créer un compte.", "OK");
                return;
            }

            var userTask = _dbConnection.Table<User>().FirstOrDefaultAsync(u => u.Login == identifiant);
            var user = await userTask;

            if (string.IsNullOrEmpty(identifiant) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Erreur", "Veuillez saisir l'identifiant et le mot de passe.", "OK");
                return;
            }

            if (user != null && user.Password == password)
            {
                // Rediriger vers la page d'accueil
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }

            //else if (user == null)
            //{
            //    // Aucun utilisateur trouvé, demander à l'utilisateur de créer un compte
            //    bool createAccount = await DisplayAlert("Erreur", "Identifiant ou mot de passe incorrect. Voulez-vous créer un compte ?", "Oui", "Non");
            //    if (createAccount)
            //    {
            //        // Rediriger vers la page de création de compte
            //        await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
            //    }
            //}

            else
            {
                await Shell.Current.DisplayAlert("Erreur", "Identifiant ou mot de passe incorrect.", "OK");
            }
        }

        private async void Label_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
    }
}
