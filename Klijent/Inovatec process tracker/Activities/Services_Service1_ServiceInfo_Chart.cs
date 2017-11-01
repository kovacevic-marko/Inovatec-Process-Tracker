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
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;

namespace Inovatec_process_tracker.Activities
{
    [Activity(Label = "Services_Service1_ServiceInfo_Chart")]
    public class Services_Service1_ServiceInfo_Chart : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Services_Service1_ServiceInfo_Chart);

            //Ovo je samo primer za entries,ovo nije bitno
            var entries = new[]
            {
                new Entry(1)
                {
                    Label = "14",
                    ValueLabel = "Radio",
                //FillColor = SKColor.Parse("#266489")
    
                },
                new Entry(-1)
                {
                Label = "15",
                ValueLabel = "Nije radio",
                Color = SKColor.Parse("#90D585")
                },
                new Entry(-1)
                {
                Label = "16",
                ValueLabel = "Nije radio",
                Color = SKColor.Parse("#90D585")
                },
                new Entry(1)
                {
                Label = "17",
                ValueLabel = "Radio",
                //FillColor = SKColor.Parse("#68B9C0")
                },
                new Entry(1)
                {
                Label = "18",
                ValueLabel = "Radio",
               // Color = SKColor.Parse("#90D585")
                },
                new Entry(1)
                {
                Label = "19",
                ValueLabel = "Radio",
               // FillColor = SKColor.Parse("#90D585")
                }
            };

            //UZIMANJE PODATAKA PREKO BAZE
            var entriesIzBaze = new Entry[10]; 

            for (int i = 0; i < 10; i++)
            {
                //Proba sa for petljom
                entriesIzBaze[i] = new Entry(1)
                {
                    Label = i.ToString(), //Label za dane
                    ValueLabel = "Radio"  //Da li je servis radio
                };

                //TEMELJ ZA PRIKAZIVANJE PODATAKA IZ BAZE
                String danZaIzabraniServis = "w";
                String daLiJeRadioServis = "w";

                if( daLiJeRadioServis.Equals("Radio"))
                {
                    entriesIzBaze[i] = new Entry(1)
                    {
                        Label = danZaIzabraniServis, //Label za dane
                        ValueLabel = "Radio"  //Da li je servis radio
                    };
                }
                else if(daLiJeRadioServis.Equals("Nije radio"))
                {
                    entriesIzBaze[i] = new Entry(-1)
                    {
                        Label = danZaIzabraniServis, //Label za dane
                        ValueLabel = "Nije radio"  //Da li je servis radio
                    };
                }
                
        }

            var chart = new LineChart() { Entries = entries};
            
            var chartView = FindViewById<ChartView>(Resource.Id.chartView);
            chartView.Chart = chart;
        }
    }
}