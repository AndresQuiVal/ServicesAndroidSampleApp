using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using ServicesAndroidAppSample.Service_connection;
using ServicesAndroidAppSample.Services;
using Android.Content;
using ServicesAndroidAppSample.Broadcast_receiver;
using Android.Support.V4.App;
using Android.Media;
using Android.Graphics;

namespace ServicesAndroidAppSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const string CHANNEL_ID = "MainChannel";

        Button startButton, stopButton, sqlitePageButton;
        MusicServiceConnection serviceConnection;

        public TextView OutputText { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            this.CreateNotificationChannel();

            startButton = FindViewById<Button>(Resource.Id.btnStartService);
            stopButton = FindViewById<Button>(Resource.Id.btnStopService);
            OutputText = FindViewById<TextView>(Resource.Id.outputText);
            sqlitePageButton = FindViewById<Button>(Resource.Id.btnSQlite);

            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;
            sqlitePageButton.Click += SqlitePageButton_Click;
        }

        private void SqlitePageButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(UserFormActivity));
            StartActivity(intent);
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            if (serviceConnection == null) serviceConnection = new MusicServiceConnection(this);

            Intent musicIntent = new Intent(this, typeof(MusicService));
            //StartService(musicIntent);
            this.SendNotification("Music Service", "Your music service has started!", 1);
            BindService(musicIntent, this.serviceConnection, Bind.AutoCreate);
        }

        private void StopButton_Click(object sender, System.EventArgs e) =>
            UnbindService(serviceConnection);/*StopService(new Intent(this, typeof(MusicService)));*/

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateNotificationChannel()
        {
            string channelName = "Main channel",
                channelDescription = "channel for publishing main notifications!";

            var notificationChannel = 
                new NotificationChannel(
                    CHANNEL_ID, channelName, 
                    NotificationImportance.Max) { Description = channelDescription };

            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
            notificationManager.CreateNotificationChannel(notificationChannel);
        }

        private void SendNotification(string title, string body, int id)
        {
            Intent intent = new Intent(this, typeof(NotificationActivity));
            intent.PutExtra("main_message", "This message is sent from MainActivity.cs!");
            PendingIntent pendingIntent = 
                PendingIntent.GetActivity(this, 1, intent, PendingIntentFlags.OneShot);

            //NotificationCompat.BigTextStyle bigText = new NotificationCompat.BigTextStyle();
            //bigText.BigText("This is a super super super super super super super super\n" +
            //    "super super super super super super super super large text.....");
            //bigText.SetSummaryText("a super giant TEXT");
            NotificationCompat.InboxStyle inboxStyle = new NotificationCompat.InboxStyle();
            inboxStyle.SetSummaryText("An image from Xamarin.Android");
            //bigPicture.BigLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.ic_launcher_round));
            inboxStyle.SetBigContentTitle("This is the Big Content Title");
            inboxStyle.SetSummaryText("This is the summary text");
            inboxStyle.AddLine("Line 1");
            inboxStyle.AddLine("Line 2");
            inboxStyle.AddLine("Line 3");
            inboxStyle.AddLine("Line 4");
            inboxStyle.AddLine("Line 5");
            NotificationCompat.Builder builder =
                new NotificationCompat.Builder(this, CHANNEL_ID)
                .SetStyle(inboxStyle)
                .SetCategory(Notification.CategoryMessage)
                .SetContentIntent(pendingIntent)
                .SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.ic_launcher_round))
                .SetContentTitle(title)
                .SetContentText(body)
                .SetSmallIcon(Resource.Drawable.ic_launcher_round)
                .SetDefaults((int)(NotificationDefaults.Sound | NotificationDefaults.Vibrate))
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));

            Notification notificationObject = builder.Build();

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(id, notificationObject);
        }
    }
}