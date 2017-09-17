using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Entity;
using RxOutlet.Views.Login;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Variables

        private LoginModel objLoginModel = new LoginModel();
        private LoginResponse objLoginResponse = null;
        private RxOutletBR objRxOutletBR = null;

        #endregion

        #region Properties
        
        public string Email
        {
            get => objLoginModel.Email;
            set => objLoginModel.Email = value;
        }
        
        public string Password
        {
            get => objLoginModel.Password;
            set => objLoginModel.Password = value;
        }
        
        public bool RememberMe
        {
            get => objLoginModel.RememberMe;
            set => objLoginModel.RememberMe = value;
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
            try
            {
                IsBusy = true;

                if (!DeviceInformation.CheckDeviceInternetAccess())
                {
                    await DisplayPopUp.NetWorkFailure();
                    return;
                }
                
                if (objLoginModel == null && string.IsNullOrEmpty(objLoginModel.Email) && string.IsNullOrEmpty(objLoginModel.Password))
                {
                    IsBusy = false;
                    Message = Messages.MandatoryFields;
                    return;
                }

                if (!Validations.IsEmailValidate(Email))
                {
                    IsBusy = false;
                    Message = Messages.InvalidEmail;
                    return;
                }

                objLoginResponse = await objRxOutletBR.Login(objLoginModel);

                if (objLoginResponse!= null && objLoginResponse.Success)
                {
                    if (objLoginResponse.IsMailConfirmed)
                    {
                        IsBusy = false;
                        await NavigationService.PusyAsync(Navigation, new Prescription(objLoginResponse.UserID));
                    }                        
                    else
                    {
                        IsBusy = false;
                        Message = Messages.ConfirmEmail;
                        return;
                    }
                }                    
                else
                {
                    IsBusy = false;
                    Message = objLoginResponse.ErrorMessage;
                }
                                   
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
