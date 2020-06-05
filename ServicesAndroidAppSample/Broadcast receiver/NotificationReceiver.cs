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

namespace ServicesAndroidAppSample.Broadcast_receiver
{
    [BroadcastReceiver(Enabled = true)]
    class NotificationReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "SetExact() handled", ToastLength.Short).Show();
        }
    }
}