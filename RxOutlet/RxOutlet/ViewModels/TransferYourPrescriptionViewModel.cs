using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class TransferYourPrescriptionViewModel : BaseViewModel
    {
        #region Variables

        private TransferPrescriptionModel objTranPres = new TransferPrescriptionModel();
        private RxOutletBR objRxOutletBR = new RxOutletBR();

        #endregion

        #region Properties

        public string PharmacyName
        {
            get => objTranPres.PharmacyName;
            set => objTranPres.PharmacyName = value;
        }

        public string PharmacyNumber
        {
            get => objTranPres.PharmacyNumber;
            set => objTranPres.PharmacyNumber = value;
        }

        public string PharmacyFax
        {
            get => objTranPres.PharmacyFax;
            set => objTranPres.PharmacyFax = value;
        }

        public string MedicationFor
        {
            get => objTranPres.MedicationFor;
            set => objTranPres.MedicationFor = value;
        }

        public string RxNumber
        {
            get => objTranPres.RxNumber;
            set => objTranPres.RxNumber = value;
        }

        public string UserID
        {
            get => objTranPres.UserID;
            set => objTranPres.UserID = value;
        }

        public Command TransferCommandClick
        {
            get => new Command(() => TransferClick());
        }

        

        #endregion

        #region Constractor
        public TransferYourPrescriptionViewModel(INavigation navigation) : base(navigation)
        {
            UserID = UserInfo.UserID;
        }
        #endregion

        #region Methods

        private async void TransferClick()
        {
            TransferPrescriptionResponse ObjTranPresResponse = null;

            try
            {
                IsBusy = true;
                if (objTranPres == null) return;

                if (string.IsNullOrEmpty(objTranPres.PharmacyName) ||
                    string.IsNullOrEmpty(objTranPres.PharmacyNumber) ||
                    string.IsNullOrEmpty(objTranPres.RxNumber) ||
                    string.IsNullOrEmpty(objTranPres.MedicationFor))
                {
                    Message = Messages.MandatoryFields;
                    //Remove
                    //Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                    return;
                }

                if (!DeviceInformation.CheckDeviceInternetAccess())
                {
                    await DisplayPopUp.NetWorkFailure();
                    return;
                }

                ObjTranPresResponse = await objRxOutletBR.TransferPrescription(objTranPres);

                if (ObjTranPresResponse.ErrorCode == (int)StatusCode.Success)
                {
                    Message = "Suceess";
                    //Remove
                    //Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                }
                else
                {
                    Message = "Failure";
                    //Remove
                    //Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                    return;
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
