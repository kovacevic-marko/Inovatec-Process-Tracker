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
    [Activity(Label = "ServicesActivity")]
    public class Services : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Services);

            FindViewById<Button>(Resource.Id.Services_btnService1).Click += (o, e) =>
            {
                StartActivity(typeof(Activities.Services_Service1));
            };
        }
    }
}