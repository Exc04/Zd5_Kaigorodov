using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zd5_2_Kai
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private double maxUserValue = 0;
        private Button _selectedButton = null; // Хранит ссылку на выбранную кнопку

        public Page2()
        {
            InitializeComponent();
        }

        // Отслеживаем движение ползунка
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > maxUserValue)
            {
                maxUserValue = e.NewValue;
            }
        }

        // Метод для сброса всех кнопок в синий цвет
        private void ResetAllButtons()
        {
            BtnStatic.StyleClass = new List<string> { "capsule-blue" };
            BtnHover.StyleClass = new List<string> { "capsule-blue" };
            BtnPressed.StyleClass = new List<string> { "capsule-blue" };

            // Принудительно обновляем стили
            BtnStatic.Style = (Style)Application.Current.Resources["capsule-blue"];
            BtnHover.Style = (Style)Application.Current.Resources["capsule-blue"];
            BtnPressed.Style = (Style)Application.Current.Resources["capsule-blue"];
        }

        // Метод для выделения кнопки (делаем серой)
        private void SelectButton(Button button)
        {
            // Сначала сбрасываем все кнопки в синий
            ResetAllButtons();

            // Выбранную кнопку делаем серой
            button.StyleClass = new List<string> { "capsule-gray" };
            button.Style = (Style)Application.Current.Resources["capsule-gray"];

            _selectedButton = button;
        }

        // Кнопка STATIC
        private void OnStaticClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectButton(button);

            int peakValue = (int)maxUserValue;
            ResultLabel.Text = $"STATIC\nМаксимальное значение: {peakValue}%";
        }

        // Кнопка HOVER
        private void OnHoverClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectButton(button);

            int currentValue = (int)EffectsSlider.Value;
            ResultLabel.Text = $"HOVER\nТекущее значение: {currentValue}%";
        }

        // Кнопка PRESSED
        private void OnPressedClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectButton(button);

            Random random = new Random();
            int randomValue = random.Next(0, 101);
            ResultLabel.Text = $"PRESSED\nСлучайное значение: {randomValue}%";
        }

        // Логика переключателей ON/OFF
        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            var sw = (Switch)sender;

            if (sw == SwitchOn)
            {
                if (e.Value)
                {
                    SwitchOff.IsToggled = false;
                    ToPage.BackgroundColor = Color.FromHex("#1a1a2e");
                }
                else
                {
                    ToPage.BackgroundColor = Color.FromHex("#2c3036");
                }
            }
            else if (sw == SwitchOff)
            {
                if (e.Value)
                {
                    SwitchOn.IsToggled = false;
                    ToPage.BackgroundColor = Color.FromHex("#1a1a2e");
                }
                else
                {
                    ToPage.BackgroundColor = Color.FromHex("#2c3036");
                }
            }
        }
    }
}