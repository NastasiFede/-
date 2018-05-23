using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace CreateAFragment
{
    [Activity(Label = "Лабораторна робота 2",
        MainLauncher = true,
        Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                int count = 1;
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Main);
                Button button = FindViewById<Button>(Resource.Id.button1);
                EditText edit = FindViewById<EditText>(Resource.Id.editText1);
                CheckBox ch1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
                ch1.Text = "Small sizes";
                button.Text = "Check";
                CheckBox ch2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
                ch2.Text = "1000x500";
                TextView tv = FindViewById<TextView>(Resource.Id.textView1);
                button.Click += delegate
                {
                    tv.Text = edit.Text + ", ";
                    if (ch1.Checked)
                        tv.Text += ch1.Text + ", ";
                    if (ch2.Checked)
                        tv.Text += ch2.Text + " ";
                };
                //ch2.Checked+=delegate
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
            }
        }
        
    }
}