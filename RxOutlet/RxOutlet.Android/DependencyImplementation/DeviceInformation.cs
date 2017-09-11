using Android.Provider;
using Xamarin.Forms;
using RxOutlet.Droid.DependencyImplementation;
using RxOutlet.Dependency;
using System;
using Android.Net;
using Android.Content;

[assembly:Dependency(typeof(DeviceInformation))]
namespace RxOutlet.Droid.DependencyImplementation
{
    public class DeviceInformation : IDeviceInformation
    {
        public bool CheckDeviceInternetAccess()
        {
            try
            {
                var connectivityManager = (ConnectivityManager)Android.App.Application.Context.
                    GetSystemService(Context.ConnectivityService);

                var activeConnection = connectivityManager.ActiveNetworkInfo;

                return (activeConnection != null && activeConnection.IsConnectedOrConnecting) ? true : false;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDeviceID()
        {
            try
            {
                return Settings.Secure.GetString(Forms.Context.ContentResolver, Settings.Secure.AndroidId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}