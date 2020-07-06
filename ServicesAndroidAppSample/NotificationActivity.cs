using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.App.Job;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ServicesAndroidAppSample.Broadcast_receiver;
using ServicesAndroidAppSample.Job_Scheduler;

namespace ServicesAndroidAppSample
{
    [Activity(Label = "NotificationActivity")]
    public class NotificationActivity : Activity
    {
        private TextView notificationLabel;
        private Button btnAlarmManager, btnJobScheduler;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NotificationLayout);

            this.notificationLabel = FindViewById<TextView>(Resource.Id.NotificationText);
            this.btnAlarmManager = FindViewById<Button>(Resource.Id.btnAlarmManager);
            this.btnJobScheduler = FindViewById<Button>(Resource.Id.btnJobScheduler);
            
            notificationLabel.Text = Intent.GetStringExtra("main_message");
            this.btnAlarmManager.Click += (sender, args) =>
            {
                Intent amIntent = new Intent(this, typeof(NotificationReceiver));
                PendingIntent pendingAlarmIntent = PendingIntent.GetBroadcast(
                    this, 1, amIntent, PendingIntentFlags.UpdateCurrent);
                AlarmManager alarmManager = (AlarmManager)GetSystemService(AlarmService);

                DateTime dt = DateTime.Now.AddMilliseconds(100000);
                alarmManager.SetExactAndAllowWhileIdle(
                    AlarmType.ElapsedRealtimeWakeup, 
                    1000000000000000000, 
                    pendingAlarmIntent);
            };

            btnJobScheduler.Click += (sender, args) =>
            {
                var builder = CreateBuilderJobSchedulerObject<ToastJobService>(this, 1);
                var jobInfo = builder.Build();
                var jobScheduler = GetSystemService(JobSchedulerService) as JobScheduler;
                jobScheduler.Schedule(jobInfo);
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Cancel(1);
        }

        public JobInfo.Builder CreateBuilderJobSchedulerObject<T>(Context context, int id) where T : JobService
        {
            var parameters = new PersistableBundle();
            parameters.PutString("message", "Scheduling job from NotificationActivity.cs!");
            var javaType = Java.Lang.Class.FromType(typeof(T));
            var component = new ComponentName(context, javaType);
            return new JobInfo.Builder(id, component)
                .SetExtras(parameters)
                .SetRequiresCharging(true)
                .SetRequiredNetworkType(NetworkType.Any)
                .SetPeriodic(60 * 1000, 5 * 60 * 1000);
        }
    }
}