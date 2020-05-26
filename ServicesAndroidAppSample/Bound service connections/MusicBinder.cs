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
using ServicesAndroidAppSample.Services;

namespace ServicesAndroidAppSample.Bound_service_connections
{
    public class MusicBinder : Binder
    {
        public MusicService Service { get; private set; }
        public MusicBinder(MusicService service) => this.Service = service;
    }
}