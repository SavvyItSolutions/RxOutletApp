using System.Collections.Generic;
using System.Collections.ObjectModel;
using RxOutlet.Views.Login;

namespace RxOutlet.Views.Menu
{
    public class RxOutletMainPageMasterViewModel
    {
        public ObservableCollection<RxOutletMainPageMenuItem> MenuItems { get; set; }
        public RxOutletMainPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<RxOutletMainPageMenuItem>(new[]
            {
                new RxOutletMainPageMenuItem() { Id = 0, Title = "Prescription", TargetType =typeof(Prescription)},
                new RxOutletMainPageMenuItem() { Id = 1, Title = "User Profile" , TargetType = typeof(Page1)},
                new RxOutletMainPageMenuItem() { Id = 1, Title = "Setting",TargetType = typeof(Page1) }
            });
        }

    }
}
