using Restaurant.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CustomShellPage();
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
