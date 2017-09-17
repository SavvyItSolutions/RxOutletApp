
namespace RxOutlet.Entity
{
    public class UploadPrescriptionModel : ObservableObject
    {
        private string physicianName = string.Empty;
        public string PhysicianName
        {
            get => physicianName;
            set => SetProperty(ref physicianName, value);
        }

        private string physicianNumber = string.Empty;
        public string PhysicianNumber
        {
            get => physicianNumber;
            set => SetProperty(ref physicianNumber, value);
        }

        private string medicationFor = string.Empty;
        public string MedicationFor
        {
            get => medicationFor;
            set => SetProperty(ref medicationFor, value);
        }

        private string userID = string.Empty;
        public string UserID
        {
            get => userID;
            set => SetProperty(ref userID, value);
        }

    }
}
