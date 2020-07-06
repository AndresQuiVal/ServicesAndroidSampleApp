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
using Java.Interop;
using ServicesAndroidAppSample.Bound_service_connections;

namespace ServicesAndroidAppSample.Service_connection
{
    public class MusicServiceConnection : Java.Lang.Object, IServiceConnection
    {
        MainActivity mainActivity;
        public MusicBinder Binder { get; set; }

        public MusicServiceConnection(MainActivity mainActivity) => 
            this.mainActivity = mainActivity;

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            this.Binder = service as MusicBinder;
            this.mainActivity.OutputText.Text = $"Service \"{name.ClassName}\" connected at: {DateTime.Now.ToLongTimeString()}";
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            this.Binder = null;
            this.mainActivity.OutputText.Text = "Service disconnected, click on Start Service to initialize";
        }
    }
}