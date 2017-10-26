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
using System.Net;
using System.Threading.Tasks;
using System.Json;
using System.IO;

namespace Inovatec_process_tracker.Activities
{
    [Activity(Label = "ServicesActivity")]
    public class Services : ListActivity
    {
        string[] servicesList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.Title = "Choose Service";

            servicesList = new String[] { "Service 1", "Service 2", "Service 3" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, servicesList);

        }

        //Eventi za elemente liste
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = servicesList[position];

            //pozicije krecu od 0
            if (position == 0)
            {
                StartActivity(typeof(Services_Service1));
            }
        }





    }
}