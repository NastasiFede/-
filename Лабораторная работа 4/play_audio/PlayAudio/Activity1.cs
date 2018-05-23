using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Database;
using Android.Util;
using System.Collections.Generic;
using System.IO;

namespace PlayAudio
{
    [Activity (Label = "����������� ������ 4", MainLauncher = true)]
    public class Activity1 : Activity
    {
        MediaPlayer _player, _player1;
        
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            SetContentView (Resource.Layout.Main);
            
            

            var playButton = FindViewById<Button> (Resource.Id.playButton);
            var pauseButton = FindViewById<Button>(Resource.Id.button1);
            var stopButton = FindViewById<Button>(Resource.Id.button2);
            var playVButton = FindViewById<Button>(Resource.Id.button3);
            var stopVButton = FindViewById<Button>(Resource.Id.button4);
            playVButton.Text = "�������� �����";
            stopVButton.Text = "������������� �����";
            playButton.Text = "������������� ���������";
            pauseButton.Text = "������������� ���������";
            stopButton.Text = "���������� ���������";
            var rb1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            var rb2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            var rb3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            var tv = FindViewById<TextView>(Resource.Id.textView1);
            tv.Text = "������ �����";
            rb1.Text = "������������ - �i��i���";
            rb2.Text = "������������ - ���������";
            rb3.Text = "������������ - �����";
            string namesong="";
            playButton.Click += delegate {
                if (rb1.Checked) {  _player = MediaPlayer.Create(this, Resource.Raw.au1); namesong = rb1.Text; }
                if (rb2.Checked) {  _player = MediaPlayer.Create(this, Resource.Raw.au2); namesong = rb2.Text; }
                if (rb3.Checked) {  _player = MediaPlayer.Create(this, Resource.Raw.au3); namesong = rb3.Text; }
                _player.Start();
                tv.Text = "������ ������>> " + namesong;
            };
            pauseButton.Click += delegate
              {
                  _player.Pause();
                  tv.Text =  namesong+ " >> ��������������";
              };
            stopButton.Click += delegate
            {
                _player.Stop();
                tv.Text = namesong + " >> �����������";
                _player1 = new MediaPlayer();
                _player = _player1;                
            };

            var videoView = FindViewById<VideoView>(Resource.Id.SampleVideoView);

            var uri = Android.Net.Uri.Parse("http://ia600507.us.archive.org/25/items/Cartoontheater1930sAnd1950s1/PigsInAPolka1943.mp4");

            videoView.SetVideoURI(uri);
            videoView.Visibility = ViewStates.Visible;
            playVButton.Click += delegate
              {
                  videoView.Start();
                  tv.Text = "����� ��������";
              };

           
            stopVButton.Click += delegate
            {
                tv.Text = "����� ��������������";

                videoView.Pause();
            };
        }
    }
}


