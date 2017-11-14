using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPTXamarinForms.Helpers;
using IPTXamarinForms.Views;
using Xamarin.Forms;

namespace IPTXamarinForms
{
    public partial class App : Application
    {
        public string IsFirstTime
        {
            get { return Settings.GeneralSettings; }
            set
            {
                if (Settings.GeneralSettings == value)

                    return;
                Settings.GeneralSettings = value;
                OnPropertyChanged();
            }
        }

        public App()
        {  
            

           InitializeComponent();
            // Check is the app running for the first time
            if (IsFirstTime == "yes")
            {
                // if this is the first time, set it to "No" and load the
                // Main Page ,which will show at the first time use
                IsFirstTime = "no";
                MainPage = new NavigationPage(new ConfigPage());
            }
            else
            {
                // If this is not the first time,
                // Go to the Settings page
                MainPage = new NavigationPage(new ConfigPage());
            }



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
