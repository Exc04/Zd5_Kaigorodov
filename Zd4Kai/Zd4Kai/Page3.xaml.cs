using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zd4Kai
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        private async void SignIn(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "OK"); return;
            }
            await Navigation.PushAsync(new MainPage());

            string[] userCredentials = { NameEntry.Text, PasswordEntry.Text };

            MessagingCenter.Send(this, "UserSignedIn", userCredentials);

        }
    }
}