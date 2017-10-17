using Rg.Plugins.Popup.Pages;
using RxOutlet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserTypePopup : PopupPage
    {
        public UserTypePopup()
        {
            InitializeComponent();
            BindingContext = new UserTypeViewModel(Navigation);
        }
    }
}