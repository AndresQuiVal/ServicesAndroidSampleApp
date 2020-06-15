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
        private ArrayAdapter listAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SQLiteLayout);

            this.sqliteConn = new SQLiteHelper();

            var users = sqliteConn.Retrieve<UserModel>().Select(e => e.Name);

            this.listAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, users.ToArray());

            sqliteListView = FindViewById<ListView>(Resource.Id.listViewSQlite);
            sqliteListView.Adapter = this.listAdapter;

            sqliteListView.ItemClick += SqliteListView_ItemClick;
        }

        private void SqliteListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var user = e.View as TextView;
            this.sqliteConn.DeleteFromUserName<UserModel>(e => e.Name == user.Text);
            this.listAdapter.Remove(user as Java.Lang.Object);
            
        }
    }
}