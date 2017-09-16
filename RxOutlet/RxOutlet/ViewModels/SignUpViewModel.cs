using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Models;
using RxOutlet.Views.Login;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {

        #region Variables

        private RegistrationModel objReg = null;
        private RegistrationResponseModel ObjRegResponse = null;
        private RxOutletBR objRxOutletBR = null;

        #endregion

        #region Properties

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set { SetProperty(ref name, value); }
        }

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

        private string confPassword = string.Empty;
        public string ConfirmPassword
        {
            get => confPassword;
            set { SetProperty(ref confPassword, value); }
        }

        private string mobileNo = string.Empty;
        public string MobileNum
        {
            get => mobileNo;
            set { SetProperty(ref mobileNo, value); }
        }

        private string captcha = string.Empty;
        public string Captcha
        {
            get => captcha;
            set { SetProperty(ref captcha, value); }
        }

        public Command SignUpClickCommand { get; }

        #endregion

        #region Constractor

        public SignUpViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                objRxOutletBR = new RxOutletBR();
                SignUpClickCommand = new Command(async () => await SignUpClick());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Events

        private async Task SignUpClick()
        {
            try
            {
                IsBusy = true;

                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(ConfirmPassword))
                {
                    Message = Messages.MandatoryFields; return;
                }

                if (!Validations.IsEmailValidate(Email))
                {
                    Message = Messages.InvalidEmail; return;
                }

                if (!Password.Equals(ConfirmPassword))
                {
                    Message = Messages.ConfirmPassword; return;
                }

                var res = Validations.IsPasswordValidate(Password);
                if (!res.Item1)
                {
                    Message = res.Item2; return;
                }

                if (!DeviceInformation.CheckDeviceInternetAccess())
                {
                    await Application.Current.MainPage.DisplayAlert("RxOutlet", Messages.CheckNetConnection, "OK");
                    return;
                }

                ObjRegResponse = await objRxOutletBR.SignUp(new RegistrationModel()
                {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword,
                    MobileNum = MobileNum,
                    Captcha = Captcha
                });

                if (ObjRegResponse != null && ObjRegResponse.Success)
                    await NavigationService.PusyAsync(Navigation, new Login(true));
                else
                    Message = ObjRegResponse.Error[0];

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
