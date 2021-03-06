using Android.App;
using Android.Widget;
using Android.OS;
using ArtLog.Services;
using System;
using ArtLog.Models;

namespace ArtLog.Droid
{
    [Activity(Label = "ArtLog", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            FilmService filmService = new FilmService();
            Root film = await filmService.GetFilms("James");

            var title = film.Search[0].Title;

            button.Click += delegate { button.Text = $"The film is: ${title}"; };
            button.Click += delegate { Console.WriteLine(title); };
        }
    }
}

