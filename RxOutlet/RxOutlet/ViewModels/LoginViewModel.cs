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

        public Command LoginClickCommand
        {
            get => new Command(async () => await LoginClick());
        }

        #endregion

        #region Constractor

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                objRxOutletBR = new RxOutletBR();
                Email = "vamsikrishna.bvk5@gmail.com";
                Password = "Vamsi@123";
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
            int statusCode = 0;
            LoginResponse objLoginResponse = null;
            try
            {
                IsBusy = true;

                if (!DeviceInformation.CheckDeviceInternetAccess())
                {
                    await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.CheckNetConnection, YesNO.OK.ToString());
                    return;
                }
                
                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
                {
                    Message = Messages.MandatoryFields; return;
                }

                if (!Validations.IsEmailValidate(Email))
                {
                    Message = Messages.InvalidEmail; return;
                }

                objLoginResponse = await objRxOutletBR.Login(new LoginModel()
                {
                    Email = Email,
                    Password = Password
                });

                if (objLoginResponse.Success)
                {
                    if (objLoginResponse.IsMailConfirmed)
                        await NavigationService.PusyAsync(Navigation, new Prescription(objLoginResponse.UserID));
                    else
                    {
                        Message = Messages.ConfirmEmail;
                        return;
                    }
                }                    
                else
                    Message = objLoginResponse.ErrorMessage;

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.ClientError, YesNO.OK.ToString());
            }
            finally
            {
                IsBusy = false;
            }

        }

        #endregion
    }
}
