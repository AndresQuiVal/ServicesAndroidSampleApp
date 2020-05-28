using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using System.Threading;
using Java.Lang;

namespace ServicesAndroidAppSample.Services
{
    [Service(Name = "com.companyname.ServicesAndroidAppSample.MusicStartedIntentService")]
    public class MusicStartedIntentService : IntentService
    {
        MediaPlayer player;
        protected override void OnHandleIntent(Intent intent) // work-queue processor
        {
            player = MediaPlayer.Create(this, Settings.System.DefaultAlarmAlertUri);
            player.Looping = false;
            player.Start();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            player.Stop();
            player = null;
        }
    }
}