using RxOutlet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferYourPrescription : ContentPage
    {
        public TransferYourPrescription()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new TransferYourPrescriptionViewModel(Navigation);
        }
    }
}