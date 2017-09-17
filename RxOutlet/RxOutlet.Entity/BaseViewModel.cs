using Xamarin.Forms;

namespace RxOutlet.Entity
{
    public class BaseViewModel : ObservableObject
    {
        protected INavigation Navigation;

        protected BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !IsBusy;
            }
        }

        private bool isNotBusy;
        public bool IsNotBusy
        {
            get => isNotBusy;
            set
            {
                if (SetProperty(ref isNotBusy, value))
                    IsBusy = !IsNotBusy;
            }
        }

        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value); 
        }
    }
}
