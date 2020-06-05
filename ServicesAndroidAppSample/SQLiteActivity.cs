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
using ServicesAndroidAppSample.Helpers;
using ServicesAndroidAppSample.Models;

namespace ServicesAndroidAppSample
{
    [Activity(Label = "SQLite Activity")]
    public class SQLiteActivity : Activity
    {
        private ListView sqliteListView;
        private SQLiteHelper sqliteConn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SQLiteLayout);

            this.sqliteConn = new SQLiteHelper();

            var users = sqliteConn.Retrieve<UserModel>().Select(e => e.Name);

            sqliteListView = FindViewById<ListView>(Resource.Id.listViewSQlite);
            sqliteListView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, users.ToArray());
        }
    }
}