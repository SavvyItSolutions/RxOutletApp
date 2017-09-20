using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Entity;
using RxOutlet.Views.Login;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {

        #region Variables

        private SignUpModel objSignUp = new SignUpModel();
        private SignUpResponseModel ObjRegResponse = null;
        private RxOutletBR objRxOutletBR = null;

        #endregion

        #region Properties
        
        public string Name
        {
            get => objSignUp.Name;
            set => objSignUp.Name = value;
        }
        
        public string Email
        {
            get => objSignUp.Email;
            set => objSignUp.Email = value;
        }

        public string Password
        {
            get => objSignUp.Password;
            set => objSignUp.Password = value;
        }
        
        public string ConfirmPassword
        {
            get => objSignUp.ConfirmPassword;
            set => objSignUp.ConfirmPassword = value;
        }

        public string MobileNum
        {
            get => objSignUp.MobileNum;
            set => objSignUp.MobileNum = value;
        }

        public string Captcha
        {
            get => objSignUp.Captcha;
            set => objSignUp.Captcha = value;
        }

        public Command SignUpClickCommand
        {
            get => new Command(async () => await SignUpClick());
        }

        #endregion

        #region Constractor

        public SignUpViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                objRxOutletBR = new RxOutletBR();
            }
            catch (Exception ex)
            {
                DisplayPopUp.ClientError();
            }
        }

        #endregion

        #region Events

        private async Task SignUpClick()
        {
            try
            {
                IsBusy = true;

                if (objSignUp == null || string.IsNullOrEmpty(objSignUp.Email) || string.IsNullOrEmpty(objSignUp.Password) || string.IsNullOrEmpty(objSignUp.ConfirmPassword))
                {
                    Message = Messages.MandatoryFields;
                    return;
                }

                if (!Validations.IsEmailValidate(objSignUp.Email))
                {
                    Message = Messages.InvalidEmail;
                    return;
                }

                if (!objSignUp.Password.Equals(objSignUp.ConfirmPassword))
                {
                    Message = Messages.ConfirmPassword;
                    return;
                }

                Tuple<bool,string> res = Validations.IsPasswordValidate(Password);
                if (!res.Item1)
                {
                    Message = res.Item2;
                    return;
                }

                if (!DeviceInformation.CheckDeviceInternetAccess())
                {
                    await DisplayPopUp.NetWorkFailure();
                    return;
                }

                ObjRegResponse = await objRxOutletBR.SignUp(objSignUp);

                if (ObjRegResponse == null) return;

                if (ObjRegResponse.Success)
                    await NavigationService.PusyAsync(Navigation, new Login(true));
                else
                    Message = ObjRegResponse.Error.FirstOrDefault();

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                DisplayPopUp.ClientError();
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

    }
}
