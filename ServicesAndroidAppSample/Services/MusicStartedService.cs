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
using ServicesAndroidAppSample.Broadcast_receiver;

namespace ServicesAndroidAppSample.Services
{
    [Service(Name = "com.companyname.ServicesAndroidAppSample.MusicStartedServcice")]
    public class MusicStartedService : Service
    {
        private MediaPlayer player;
        private MusicBroadcast musicBroadcast;

        public override IBinder OnBind(Intent intent) => null; // main method for bound services


        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId) 
            // Main method for started services
        {
            musicBroadcast = new MusicBroadcast();
            player = MediaPlayer.Create(this, Settings.System.DefaultAlarmAlertUri);
            player.Looping = true;
            player.Start();

            //Intent receiverIntent = new Intent();
            //receiverIntent.SetAction("MusicReceiverIntent");
            //receiverIntent.SetClass(this, typeof(MusicBroadcast));
            RegisterReceiver(musicBroadcast, new IntentFilter("com.companyname.ServicesAndroidAppSample.MusicReceiverIntent"));
            //SendBroadcast(receiverIntent);
            return /*base.OnStartCommand(intent, flags, startId)*/StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            //player.Stop();
            //player = null;
        }
    }
}