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
using Android.Content.PM;
using System.Threading;

namespace RxOutlet.Droid
{
    [Activity(Label = "RxOutlet", MainLauncher = true, NoHistory =true, Theme = "@style/SplashTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(1000);
            StartActivity(typeof(MainActivity));
        }
    }
}