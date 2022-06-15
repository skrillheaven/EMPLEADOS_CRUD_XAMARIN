using CRUD_Final.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_Final
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new HomePage());
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
