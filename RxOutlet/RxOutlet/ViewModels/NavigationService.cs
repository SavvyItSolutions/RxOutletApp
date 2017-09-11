using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public static class NavigationService
    {
        private static bool isNavigate;

        public static async Task PusyAsync(INavigation navigation, Page page, Animation animation = null)
        {
            try
            {
                if (isNavigate) return;

                isNavigate = true;
                await navigation.PushAsync(page);
                isNavigate = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task PopAsync(INavigation navigation, Animation animation = null)
        {
            try
            {
                if (isNavigate) return;

                isNavigate = true;
                await navigation.PopAsync();
                isNavigate = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
