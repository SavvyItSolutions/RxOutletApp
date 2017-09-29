using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using System;
using Android.Content;
using RxOutlet.Common;

namespace RxOutlet.Droid
{
    [Activity(Label = "RxOutlet", Icon = "@drawable/Logo", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation =ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //AndroidUserLoginFirstTime obj = new AndroidUserLoginFirstTime();

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //obj.LoginFirstTime();
            LoadApplication(new App());
        }
       
    }
}

