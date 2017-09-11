using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.Entity
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
                if(SetProperty(ref isNotBusy, value))
                    IsBusy = !IsNotBusy;
            }
        }
    }
}
