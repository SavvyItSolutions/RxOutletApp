
namespace RxOutlet.Entity
{
    public class LoginModel : BaseViewModel
    {
        private string email = string.Empty;
        public string Email
        {
            get => email;
            set { SetProperty(ref email, value); }
        }

        private string password = string.Empty;
        public string Password
        {
            get => password;
            set { SetProperty(ref password, value); }
        }

        private bool remberMe;
        public bool RememberMe
        {
            get => remberMe;
            set { SetProperty(ref remberMe, value); }
        }
    }
}
