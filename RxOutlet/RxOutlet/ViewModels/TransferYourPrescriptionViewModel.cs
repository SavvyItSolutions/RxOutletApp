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

        public Command TransferCommandClick
        {
            get => new Command(() => TransferClick());
        }

        

        #endregion

        #region Constractor
        public TransferYourPrescriptionViewModel(INavigation navigation) : base(navigation)
        {
        }
        #endregion

        #region Methods

        private async void TransferClick()
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }
        #endregion


    }
}
