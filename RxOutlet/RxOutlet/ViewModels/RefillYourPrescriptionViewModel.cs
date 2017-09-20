using RxOutlet.BusinessRules;
using RxOutlet.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class RefillYourPrescriptionViewModel : BaseViewModel
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
                    new RefillPrescription(){PrescriptionName="Prescription Number - 1",PrescriptionNum="Mediction Name - 1",LastDate="12/12/2016",RefillItems="No.of weeks to Refill - 1" },
                   new RefillPrescription(){PrescriptionName="Prescription Number - 1",PrescriptionNum="Mediction Name - 2",LastDate="12/12/2016",RefillItems="No.of weeks to Refill - 2" },
                    new RefillPrescription(){PrescriptionName="Prescription Number - 3",PrescriptionNum="Mediction Name - 3",LastDate="12/12/2016",RefillItems="No.of weeks to Refill - 3" },
                    new RefillPrescription(){PrescriptionName="Prescription Number - 4",PrescriptionNum="Mediction Name - 4",LastDate="12/12/2016",RefillItems="No.of weeks to Refill - 4" },
                    new RefillPrescription(){PrescriptionName="Prescription Number - 5",PrescriptionNum="Mediction Name - 5",LastDate="12/12/2016",RefillItems="No.of weeks to Refill - 5" },
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
