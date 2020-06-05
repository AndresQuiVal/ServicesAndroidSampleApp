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
    [Activity(Label = "UserFormActivity")]
    public class UserFormActivity : Activity
    {
        private EditText nameEditText, lastNameEditText;
        private Button btnSaveUser, btnViewUsers;

        private SQLiteHelper sqlService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserForm);

            this.sqlService = new SQLiteHelper();
            //this.sqlService.DeleteAll();

            this.nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
            this.lastNameEditText = FindViewById<EditText>(Resource.Id.lastNameEditText);
            this.btnSaveUser = FindViewById<Button>(Resource.Id.btnSave);
            this.btnViewUsers = FindViewById<Button>(Resource.Id.btnViewUsers);

            this.btnSaveUser.Click += (sender, args) =>
            {
                string text = $"Succesfully saved user with name {lastNameEditText.Text}";
                try
                {
                    sqlService.Insert(new UserModel()
                    { Name = nameEditText.Text, LastName = lastNameEditText.Text });
                } catch (Exception ex)
                {
                    text = ex.Message;
                }

                Toast.MakeText(this, text, ToastLength.Long).Show();
            };

            this.btnViewUsers.Click += BtnViewUsers_Click;
        }

        private void BtnViewUsers_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SQLiteActivity));
            StartActivity(intent);
        }
    }
}