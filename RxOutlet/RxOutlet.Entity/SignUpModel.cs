
namespace RxOutlet.Entity
{
    public class SignUpModel : ObservableObject
    {
        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string email = string.Empty;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private string mobileNum = string.Empty;
        public string MobileNum
        {
            get => mobileNum;
            set => SetProperty(ref mobileNum, value);
        }

        private string password = string.Empty;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private string confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }

        private string captcha = string.Empty;
        public string Captcha
        {
            get => captcha;
            set => SetProperty(ref captcha, value);
        }
        
    }
}
