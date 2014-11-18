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
using DBDemo.ORM;

namespace DBDemo
{
    [Activity(Label = "DeleteTaskActivity")]
    public class DeleteTaskActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.DeleteTask);
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += btnDelete_Click;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();            
            EditText txtTaskID = FindViewById<EditText>(Resource.Id.txtTaskID);
            string result = dbr.DeleteTask(int.Parse(txtTaskID.Text));
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}