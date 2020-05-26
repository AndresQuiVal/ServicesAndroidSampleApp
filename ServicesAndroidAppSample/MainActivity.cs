using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using ServicesAndroidAppSample.Service_connection;
using ServicesAndroidAppSample.Services;
using Android.Content;

namespace ServicesAndroidAppSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button startButton, stopButton;
        MusicServiceConnection serviceConnection;
        public TextView OutputText { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            startButton = FindViewById<Button>(Resource.Id.btnStartService);
            stopButton = FindViewById<Button>(Resource.Id.btnStopService);
            OutputText = FindViewById<TextView>(Resource.Id.outputText);

            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            if (serviceConnection == null) serviceConnection = new MusicServiceConnection(this);

            Intent musicIntent = new Intent(this, typeof(MusicService));
            BindService(musicIntent, this.serviceConnection, Bind.AutoCreate);
        }

        private void StopButton_Click(object sender, System.EventArgs e) => 
            UnbindService(serviceConnection);

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}