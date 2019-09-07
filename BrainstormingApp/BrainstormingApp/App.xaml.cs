using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrainstormingApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = String.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MyTabbedPage());
        }
        public App(string dbLocation)
        {
            DatabaseLocation = dbLocation;
            InitializeComponent();
            MainPage = new NavigationPage(new MyTabbedPage());
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
