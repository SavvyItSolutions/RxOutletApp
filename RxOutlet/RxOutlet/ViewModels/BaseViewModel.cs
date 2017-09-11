
namespace RxOutlet.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
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
    }
}
