﻿using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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

        public static async Task PushPopupAsync(INavigation navigation, PopupPage page, Animation animation = null)
        {
            try
            {
                if (isNavigate) return;

                isNavigate = true;
                await navigation.PushPopupAsync(page);
                isNavigate = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task PopAllPopupAsync(INavigation navigation, Animation animation = null)
        {
            try
            {
                if (isNavigate) return;

                isNavigate = true;
                await navigation.PopAllPopupAsync();
                isNavigate = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task RemovePopupPageAsync(INavigation navigation, PopupPage popupPage, Animation animation = null)
        {
            try
            {
                if (isNavigate) return;

                isNavigate = true;
                await navigation.RemovePopupPageAsync(popupPage);
                isNavigate = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
