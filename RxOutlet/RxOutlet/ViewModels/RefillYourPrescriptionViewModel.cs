using RxOutlet.BusinessRules;
using RxOutlet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class RefillYourPrescriptionViewModel : BaseViewModel
    {

        #region Variables

        private RxOutletBR objRxOutletBR = null;
        private List<RefillPrescription> listRefill = new List<RefillPrescription>();

        #endregion

        #region Properties

        private string prescSearch = string.Empty;
        public string PrescSearch
        {
            get => prescSearch;
            set
                {
                if (SetProperty(ref prescSearch, value))
                {
                    if (string.IsNullOrEmpty(PrescSearch))
                    {
                        ListOfPrescription = listRefill;
                    }
                       
                }
            }
        }
        private List<RefillPrescription> listOfPrescription = null;
        public List<RefillPrescription> ListOfPrescription
        {
            get => listOfPrescription;
            set => SetProperty(ref listOfPrescription, value); 
        }

        public Command SearchCommandClick
        {
            get => new Command(() => SearchClick());
        }

        
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
            listRefill = ListOfPrescription;
        }

        private async void SearchClick()
        {
            try
            {
                ListOfPrescription = listRefill.Where(x => x.PrescriptionName.Contains(PrescSearch) || x.PrescriptionNum.Contains(PrescSearch)).ToList();

                if(ListOfPrescription.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("RxOutlet", "No items found", "Ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    new RefillPrescription(){PrescriptionName="Citalopram",PrescriptionNum="1234",LastDate="12/12/2016",RefillItems="2" },
                   new RefillPrescription(){PrescriptionName="Prescription Number - 1",PrescriptionNum="Doxycycline",LastDate="12/12/2016",RefillItems="No.of weeks to Refill - 2" },
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
