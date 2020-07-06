using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ServicesAndroidAppSample
{
    [Activity(Label = "SplashActivity", Theme = "@style/SplashStyle", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Intent intentMainAct = new Intent(this, typeof(MainActivity));
            await LongRunningTask();
            //StartActivity(intentMainAct);
        }

        private async Task LongRunningTask()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(8000);
                StartActivity(new Intent(this, typeof(MainActivity)));
            });
        }

        public override void OnBackPressed()
        {
        }
    }
}