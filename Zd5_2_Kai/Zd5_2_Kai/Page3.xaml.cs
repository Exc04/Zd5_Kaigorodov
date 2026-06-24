using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zd5_2_Kai
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
            // Проверка на пустоту полей
            if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "OK"); return;
            }
            // Открытие каресели страниц за место текущего экрана
            await Navigation.PushAsync(new MainPage());

            // Перевод логина и пароля в один массив строк
            string[] userCredentials = { NameEntry.Text, PasswordEntry.Text };

            // Отправка массива с помощью MessagingCenter
            MessagingCenter.Send(this, "UserSignedIn", userCredentials);

        }
    }
}