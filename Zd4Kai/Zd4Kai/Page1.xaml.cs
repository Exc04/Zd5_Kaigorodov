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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void OnDataChanged(object sender, EventArgs e)
        {
            CalculateLoan();
        }

        private void CalculateLoan() //Расчитать кредит
        {
            // Проверка вводимых значений. Если пусто или не числа — выходим
            if (!double.TryParse(CreditSum.Text, out double sum) ||
                !int.TryParse(TimeCredit.Text, out int months) || months <= 0) return;

            // Расчёт процента (делим на 100)
            double rate = RateSlider.Value / 100;

            // Расчёт переплаты и общей суммы
            double overpayment = sum * rate * (months / 12.0); // Переплата за всё время
            double totalPay = sum + overpayment;               // Общая сумма
            double monthlyPayment = totalPay / months;         // Ежемесячный платёж

            // Вывод результатов на экран
            Payment.Text = $"Ежемесячный платёж: {Math.Round(monthlyPayment, 2)} руб.";
            Sum.Text = $"Общая сумма: {Math.Round(totalPay, 2)} руб.";
            Overpayment.Text = $"Переплата: {Math.Round(overpayment, 2)} руб.";
        }
    }
}