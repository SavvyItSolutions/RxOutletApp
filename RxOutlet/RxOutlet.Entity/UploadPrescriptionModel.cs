
namespace RxOutlet.Entity
{
    public class UploadPrescriptionModel : BaseViewModel
    {
        private string email = string.Empty;
        public string Email
        {
            get => email;
            set { SetProperty(ref email, value); }
        }

        private string phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get => phoneNumber;
            set { SetProperty(ref phoneNumber, value); }
        }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set { SetProperty(ref name, value); }
        }

        private string title = string.Empty;
        public string Title
        {
            get => title;
            set { SetProperty(ref title, value); }
        }

        private string description = string.Empty;
        public string Description
        {
            get => description;
            set { SetProperty(ref description, value); }
        }

        private string filepath = string.Empty;
        public string Filepath
        {
            get => filepath;
            set { SetProperty(ref filepath, value); }
        }

        private string userID = string.Empty;
        public string UserID
        {
            get => userID;
            set { SetProperty(ref userID, value); }
        }

        private string createdDate = string.Empty;
        public string CreatedDate
        {
            get => createdDate;
            set { SetProperty(ref createdDate, value); }
        }
    }
}
