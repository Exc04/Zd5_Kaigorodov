using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Zd4Kai
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            myDatePicker.Date = DateTime.Today; // Ставим текущую дату при старте
            LoadRates();
        }
        // Вызывается автоматически при выборе даты в DatePicker
        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            LoadRates();
        }

        private void LoadRates()
        {
            USD.Text = "USD: 80 руб.";
            EUR.Text = "EUR: 86 руб.";
        }
    }
}