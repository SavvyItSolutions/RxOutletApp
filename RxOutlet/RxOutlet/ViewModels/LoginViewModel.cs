using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Models;
using RxOutlet.Views.Login;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Variables

        private LoginModel objLoginModel = null;
        private RxOutletBR objRxOutletBR = null;

        #endregion

        #region Properties

        private string email = string.Empty;
        public string Email
        {
            get => email;
            set { SetProperty(ref email, value); }
        }

        private string password = string.Empty;
        public string Password
        {
            get => password;
            set { SetProperty(ref password, value); }
        }

        private bool rememberMe = false;
        public bool RememberMe
        {
            get => rememberMe;
            set { SetProperty(ref rememberMe, value); }
        }

        public Command LoginClickCommand { get; }

        #endregion

        #region Constractor

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                objRxOutletBR = new RxOutletBR();
                LoginClickCommand = new Command(async () => await LoginClick());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Events

        private async Task LoginClick()
        {
            int statusCode;

            IsBusy = true;

            if(!DeviceInformation.CheckDeviceInternetAccess())
            {
                await Application.Current.MainPage.DisplayAlert("RxOutlet","Please check the internet connection", "OK");
                return;
            }

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                objLoginModel.Email = Email;
                objLoginModel.Password = Password;

                statusCode =  await objRxOutletBR.Login(new LoginModel() { Email = Email, Password = Password });

                if (statusCode == (int)StatusCode.Success)
                    await NavigationService.PusyAsync(Navigation, new Prescription());
                else
                    Message = "Check the server";
            }
            else
                Message = "Please enter Mandatory Fields";

            IsBusy = false;
        }
        
        #endregion 
    }
}
