using Android.App;
using Android.Widget;
using Android.OS;

namespace Inovatec_process_tracker
{
    [Activity(Label = "Inovatec_process_tracker", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.Main_btnServices).Click += (o, e) =>
            {
                StartActivity(typeof(Activities.Services));
            };

            
        }
    }
}

