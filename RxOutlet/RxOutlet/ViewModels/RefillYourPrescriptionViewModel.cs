using RxOutlet.BusinessRules;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class RefillYourPrescriptionViewModel : ViewModelBase
    {

        #region Variables

        private RxOutletBR objRxOutletBR = null;

        #endregion

        #region Properties

        public List<RefillPrescription> ListOfPrescription { get; set; }

        #endregion

        #region Constractor

        public RefillYourPrescriptionViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                objRxOutletBR = new RxOutletBR();
                PageLoad();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void PageLoad()
        {
            RefillPrescription obj = new RefillPrescription();
            ListOfPrescription = await obj.GetList();
        }

        #endregion


    }

    public class RefillPrescription
    {
        public string PrescriptionNum { get; set; }
        public string PrescriptionName { get; set; }
        public string LastDate { get; set; }
        public string RefillItems { get; set; }

        public async Task<List<RefillPrescription>> GetList()
        {
            try
            {
                List<RefillPrescription> list = new List<RefillPrescription>()
                {
                    new RefillPrescription(){PrescriptionName="PrescriptionName1",PrescriptionNum="PrescriptionNum1",LastDate="LastDate1",RefillItems="RefillItems1" },
                    new RefillPrescription(){PrescriptionName="PrescriptionName2",PrescriptionNum="PrescriptionNum2",LastDate="LastDate2",RefillItems="RefillItems2" },
                    new RefillPrescription(){PrescriptionName="PrescriptionName3",PrescriptionNum="PrescriptionNum3",LastDate="LastDate3",RefillItems="RefillItems3" },
                    new RefillPrescription(){PrescriptionName="PrescriptionName4",PrescriptionNum="PrescriptionNum4",LastDate="LastDate4",RefillItems="RefillItems4" },
                };
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
