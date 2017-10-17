using RxOutlet.Entity;
using RxOutlet.Views.LocatePrescriptions;
using System;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class UserTypeViewModel: BaseViewModel
    {
        #region Properties

        public Command ExistStoreUserCommand
        {
            get => new Command(() => ExistStoreUser());
        }

        public Command RegisterOnlineCommand
        {
            get => new Command(() => RegisterOnline());
        }

        #endregion

        public UserTypeViewModel(INavigation navigation) : base(navigation)
        {
            
        }

        #region Events

        private async void ExistStoreUser()
        {
            try
            {
                await NavigationService.PopAllPopupAsync(Navigation);
                await NavigationService.PusyAsync(Navigation, new LocatePrescription());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void RegisterOnline()
        {
            try
            {
                await NavigationService.PopAllPopupAsync(Navigation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion 
    }
}
