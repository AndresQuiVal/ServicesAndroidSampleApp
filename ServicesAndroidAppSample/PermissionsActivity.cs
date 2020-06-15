using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace ServicesAndroidAppSample
{
    [Activity(Label = "PermissionsActivity")]
    public class PermissionsActivity : Activity
    {
        private Button btnCheckPermission, btnAddPermission, btnNeedsRationale;
        private EditText entryPermission;
        private LinearLayout mainLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.permissions_layout);

            this.btnCheckPermission = FindViewById<Button>(Resource.Id.btnVerifyPermission);
            this.btnAddPermission = FindViewById<Button>(Resource.Id.btnEnablePermission);
            this.btnNeedsRationale = FindViewById<Button>(Resource.Id.btnNeedsRationale);
            this.entryPermission = FindViewById<EditText>(Resource.Id.entryPermission);
            this.mainLayout = FindViewById<LinearLayout>(Resource.Id.main_layout);
            
            this.btnCheckPermission.Click += BtnCheckPermission_Click;
            this.btnNeedsRationale.Click += BtnNeedsRationale_Click;
            this.btnAddPermission.Click += BtnAddPermission_Click;
        }

        private void BtnAddPermission_Click(object sender, EventArgs e)
        {
            ActivityCompat.RequestPermissions(this, new string[] { 
                Manifest.Permission.Camera, 
                Manifest.Permission.ReadExternalStorage,
                Manifest.Permission.AccessFineLocation }, 1);

            Snackbar.Make(
                this.mainLayout, 
                $"{this.entryPermission.Text} PERMISSION BEING REQUESTED",
                Snackbar.LengthShort).Show();
        }

        private void BtnNeedsRationale_Click(object sender, EventArgs e)
        {
            bool needsRationale = 
                ActivityCompat.ShouldShowRequestPermissionRationale(this, this.entryPermission.Text);

            string needsRationaleText = "DOES NOT needs rationale";
            if (needsRationale) needsRationaleText = "NEEDS RATIONALE!";
            Snackbar.Make(this.mainLayout, needsRationaleText, Snackbar.LengthShort).Show();
        }

        private void BtnCheckPermission_Click(object sender, EventArgs e)
        {
            string text = "DOES NOT have permission!";

            if (ContextCompat.CheckSelfPermission(this, this.entryPermission.Text) == (int)Permission.Granted)
                text = "HAS permission!";

            Snackbar.Make(this.mainLayout, text, Snackbar.LengthLong).Show();
        }
    }
}