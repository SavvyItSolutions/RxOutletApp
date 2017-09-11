using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        protected INavigation Navigation;

        public ViewModelBase(INavigation navigation) 
        {
            Navigation = navigation;
        }

        private string message;

        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }
    }
}
