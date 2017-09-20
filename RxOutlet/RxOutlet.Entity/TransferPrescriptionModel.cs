
namespace RxOutlet.Entity
{
    public class TransferPrescriptionModel : ObservableObject
    {
        private string pharmacyName = string.Empty;
        public string PharmacyName
        {
            get => pharmacyName;
            set => SetProperty(ref pharmacyName, value);
        }

        private string pharmaryNumber = string.Empty;
        public string PharmacyNumber
        {
            get => pharmaryNumber;
            set => SetProperty(ref pharmaryNumber, value);
        }

        private string pharmacyFax = string.Empty;
        public string PharmacyFax
        {
            get => pharmacyFax;
            set => SetProperty(ref pharmacyFax, value);
        }

        private string medicationFor = string.Empty;
        public string MedicationFor
        {
            get => medicationFor;
            set => SetProperty(ref medicationFor, value);
        }

        private string rxNumber = string.Empty;
        public string RxNumber
        {
            get => rxNumber;
            set => SetProperty(ref rxNumber, value);
        }

        public string TransferPrescriptionID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
