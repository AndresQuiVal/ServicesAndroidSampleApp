using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ServicesAndroidAppSample.Bound_service_connections;

namespace ServicesAndroidAppSample.Services
{
    [Service(Name = "com.companyname.ServicesAndroidAppSample.MusicService")]
    public class MusicService : Service
    {
        MediaPlayer player;
        public IBinder Binder { get; set; }
        public override IBinder OnBind(Intent intent)
        {
            Toast.MakeText(this, "OnBind() of service activated", ToastLength.Long).Show();
            Binder = new MusicBinder(this);
            player = MediaPlayer.Create(this, Settings.System.DefaultRingtoneUri);
            player.Looping = true;
            player.Start();
            return this.Binder;
        }

        public override bool OnUnbind(Intent intent)
        {
            Toast.MakeText(this, "OnUnbind() of service activated", ToastLength.Short).Show();
            player.Stop();
            return base.OnUnbind(intent);
        }

        public override void OnDestroy()
        {
            Toast.MakeText(this, "OnDestroy() of service activated", ToastLength.Short).Show();
            player.Stop();
            player = null;
            Binder = null; // free space from heap
            base.OnDestroy();
        }
    }
}