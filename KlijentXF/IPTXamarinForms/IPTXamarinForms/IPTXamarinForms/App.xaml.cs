using IPTXamarinForms.Views;
using Xamarin.Forms;

namespace IPTXamarinForms
{
    public partial class App : Application
    {
        //public string IsFirstTime
        //{
        //    get { return Settings.IsFirstRun; }
        //    set
        //    {
        //        if (Settings.IsFirstRun == value)

        //            return;
        //        Settings.IsFirstRun = value;
        //        OnPropertyChanged();
        //    }
        //}

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new WelcomePage());
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
