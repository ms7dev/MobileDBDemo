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
    [Activity(Label = "InsertTaskActivity")]
    public class InsertTaskActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.InsertTask);

            Button btnAdd = FindViewById<Button>(Resource.Id.btnTask);
            btnAdd.Click += btnAdd_Click;

        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            DBRepository dbr = new DBRepository();
            string result = dbr.InsertRecord(txtTask.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}