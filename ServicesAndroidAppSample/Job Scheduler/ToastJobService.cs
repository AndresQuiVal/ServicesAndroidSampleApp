using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.App.Job;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Provider;
using Android.Widget;
using Xamarin.Essentials;

namespace ServicesAndroidAppSample.Job_Scheduler
{
    [Service(
        Name = "com.companyname.ServicesAndroidAppSample.Job_Scheduler.ToastJobService",
        Permission = "android.permission.BIND_JOB_SERVICE")] // permission required
    class ToastJobService : JobService
    {
        public JobParameters parameters;
        private ExecuteWorkerThreadWork wThread;
        public override bool OnStartJob(JobParameters @params)
        {
            this.parameters = @params;
            Toast.MakeText(
                this, 
                @params.Extras.GetString("message"), ToastLength.Short)
                .Show();

            //Task.Run(() =>
            //{
            //    for(int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(3000);
            //        MainThread.BeginInvokeOnMainThread(() => Toast.MakeText(
            //            this, 
            //            $"Downloading {i} files...",
            //            ToastLength.Long).Show());
            //    }

            //    JobFinished(@params, true);
            //});

            wThread = new ExecuteWorkerThreadWork();
            wThread.ExecuteLongRunningTask(this);

            JobFinished(@params, true);
            return true;
        }

        public override bool OnStopJob(JobParameters @params)
        {
            wThread = null;
            return true;
        }

        public class ExecuteWorkerThreadWork
        {
            public void ExecuteLongRunningTask(Context context)
            {
                //MediaPlayer player = MediaPlayer.Create(context, Settings.System.DefaultRingtoneUri);
                Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(3000);
                        //player.Looping = true;
                        //player.Start();
                        MainThread.BeginInvokeOnMainThread(() => Toast.MakeText(
                            context,
                            $"Downloading {i} files...",
                            ToastLength.Long).Show());
                    }
                });
            }
        }
    }

    
}