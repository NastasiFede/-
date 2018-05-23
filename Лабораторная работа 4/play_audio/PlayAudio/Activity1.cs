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
    [Activity (Label = "Лаборатоная работа 4", MainLauncher = true)]
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
            playVButton.Text = "Включить видео";
            stopVButton.Text = "Приостановить видео";
            playButton.Text = "Воспроизвести аудиофайл";
            pauseButton.Text = "Приостановить аудиофайл";
            stopButton.Text = "Остановить аудиофайл";
            var rb1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            var rb2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            var rb3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            var tv = FindViewById<TextView>(Resource.Id.textView1);
            tv.Text = "Ожидаю аудио";
            rb1.Text = "Электрофорез - Пiдлiток";
            rb2.Text = "Электрофорез - Звездопад";
            rb3.Text = "Электрофорез - Волны";
            string namesong="";
            playButton.Click += delegate {
                if (rb1.Checked) {  _player = MediaPlayer.Create(this, Resource.Raw.au1); namesong = rb1.Text; }
                if (rb2.Checked) {  _player = MediaPlayer.Create(this, Resource.Raw.au2); namesong = rb2.Text; }
                if (rb3.Checked) {  _player = MediaPlayer.Create(this, Resource.Raw.au3); namesong = rb3.Text; }
                _player.Start();
                tv.Text = "Сейчас играет>> " + namesong;
            };
            pauseButton.Click += delegate
              {
                  _player.Pause();
                  tv.Text =  namesong+ " >> приостановлена";
              };
            stopButton.Click += delegate
            {
                _player.Stop();
                tv.Text = namesong + " >> остановлена";
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
                  tv.Text = "Видео запущено";
              };

           
            stopVButton.Click += delegate
            {
                tv.Text = "Видео приостановлено";

                videoView.Pause();
            };
        }
    }
}


