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
    [Activity(Label = "Applications")]
    public class Applications : ListActivity
    {
        String[] applicationsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.Title = "Choose Application";

            applicationsList = new String[] { "Applicaiton 1", "Application 2", "Application 3" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, applicationsList);

        }
    }
}