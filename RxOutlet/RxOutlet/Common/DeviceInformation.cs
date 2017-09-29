using RxOutlet.Dependency;
using System;
using Xamarin.Forms;

namespace RxOutlet.Common
{
    public static class DeviceInformation 
    {
        public static bool UserLoginFirstTime()
        {
            try
            {
                return DependencyService.Get<IUserLoginFirstTime>().LoginFirstTime();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool CheckDeviceInternetAccess()
        {
            try
            {
                return DependencyService.Get<IDeviceInformation>().CheckDeviceInternetAccess();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetDeviceID()
        {
            try
            {
                return DependencyService.Get<IDeviceInformation>().GetDeviceID();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
