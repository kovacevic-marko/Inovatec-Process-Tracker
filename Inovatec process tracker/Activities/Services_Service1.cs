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
    [Activity(Label = "Services_Service1Activity")]
    public class Services_Service1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Services_Service1);

            FindViewById<Button>(Resource.Id.Services_Service1_btnRefresh).Click += (o, e) =>
            {
                //ovde ide kod za refresovanje statusa, sql query
            };
            FindViewById<Button>(Resource.Id.Services_Service1_btnServiceInfo).Click += (o, e) =>
            {
                StartActivity(typeof(Activities.Services_Service1_ServiceInfo));
            };
        }
    }
}