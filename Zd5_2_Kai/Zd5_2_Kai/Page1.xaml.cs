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
    public partial class Page1 : ContentPage
    {
        // Переменная для хранения принятого пароля
        private string _password = string.Empty;

        public Page1()
        {

            InitializeComponent();

            // Подписываемся на получение массива строк от LoginPage
            MessagingCenter.Subscribe<Page3, string[]>(this, "UserSignedIn", (sender, credentials) =>
            {
                if (credentials != null && credentials.Length == 2)
                {
                    NameBtn.Text = credentials[0]; // Первое значение — имя пользователя
                    _password = credentials[1];          // Второе значение — пароль
                }
            });

        }

        // Клик по имени пользователя — вывод пароля
        private async void NameClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_password))
            {
                await DisplayAlert("Информация", "Данные о пароле не найдены", "OK");
            }
            else
            {
                await DisplayAlert("Информация", $"Ваш пароль: {_password}", "OK");
            }
        }

        // Клик по серой кнопке перелистывания на ThirdPage
        private async void Page2Click(object sender, EventArgs e)
        {
            // Перелистываем карусель на третий экран настроек
            var carousel = App.Current.MainPage.Navigation.NavigationStack.LastOrDefault() as CarouselPage;
            if (carousel == null) carousel = this.Parent as CarouselPage;

            if (carousel != null && carousel.Children.Count > 1)
            {
                carousel.CurrentPage = carousel.Children[1]; // Листаем на ThirdPage
            }
        }
    }
}