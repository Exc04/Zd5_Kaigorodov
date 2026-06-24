using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zd5_2_Kai
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CarouselPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
