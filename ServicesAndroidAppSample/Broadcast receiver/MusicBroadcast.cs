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
using ServicesAndroidAppSample.Services;

namespace ServicesAndroidAppSample.Broadcast_receiver
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { "com.companyname.ServicesAndroidAppSample.MusicReceiverIntent" })]
    public class MusicBroadcast : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            MediaPlayer player = MediaPlayer.Create(context, Settings.System.DefaultRingtoneUri);
            player.Looping = true;
            player.Start();
        }
    }
}