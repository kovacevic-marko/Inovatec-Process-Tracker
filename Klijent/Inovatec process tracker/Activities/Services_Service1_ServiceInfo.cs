using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Inovatec_process_tracker.Activities
{
    [Activity(Label = "Services_Service1_ServiceInfo")]
    public class Services_Service1_ServiceInfo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.Title = "Select date to display informations";
            SetContentView(Resource.Layout.Services_Service1_ServiceInfo);

            FindViewById<DatePicker>(Resource.Id.Services_Service1_ServiceInfo_datePicker).MinDate = 1507154400000; //ovo je 5. oktobar konvertovan u milisekunde
            FindViewById<DatePicker>(Resource.Id.Services_Service1_ServiceInfo_datePicker).MaxDate = Java.Lang.JavaSystem.CurrentTimeMillis(); //uzima trenutni datum u milisekundama

            FindViewById<Button>(Resource.Id.Services_Service1_ServiceInfo_btnOk).Click += (o, e) =>
            {
                //ovde ide redirekt za stranu za prikazivanje informacija o izabranom datumu
            };
            FindViewById<Button>(Resource.Id.Services_Service1_ServiceInfo_btnCancel).Click += (o, e) =>
            {
                base.OnBackPressed();
            };
        }
    }
}