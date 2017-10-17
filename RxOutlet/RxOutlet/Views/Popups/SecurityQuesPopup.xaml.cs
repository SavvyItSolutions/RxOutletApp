using Rg.Plugins.Popup.Pages;
using RxOutlet.ViewModels;
using RxOutlet.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityQuesPopup : PopupPage
    {
        public SecurityQuesPopup()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            await NavigationService.PopAllPopupAsync(Navigation);
            await Navigation.PushAsync(new Prescription());
        }
    }
}