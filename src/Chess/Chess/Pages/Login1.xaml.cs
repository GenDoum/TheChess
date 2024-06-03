using ChessLibrary;
using testPersistance;

namespace Chess.Pages;
public partial class Login1 : ContentPage
{
    public List<User> users;

    public Login1()
    {
        InitializeComponent();
    }

    void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // R�cup�re les champs des entry et v�rifie s'ils sont vides
        string entryPseudo = UsernameEntry.Text;
        string entryPassword = PasswordEntry.Text;


        if (string.IsNullOrWhiteSpace(entryPseudo) || string.IsNullOrWhiteSpace(entryPassword))
        {
            DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
        }
        else
        {
            // V�rifie si le mot de passe est correct

            if (entryPassword == "1234")
            {
                // Redirige vers la page de connexion

                Shell.Current.GoToAsync("//page/LoginSecondPlayer");
            }
            else
            {
                DisplayAlert("Erreur", "Mot de passe incorrect", "OK");
            }
        }
    }

    async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/MainPage");
    }

    async void OnConnexionButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/LoginSecondPlayer");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/MainPage");
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }
}