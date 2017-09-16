using RxOutlet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FillNewPrescription : ContentPage
    {
        public FillNewPrescription(string UserID)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new FillNewPrescriptionViewModel(Navigation,UserID);
        }
    }
}