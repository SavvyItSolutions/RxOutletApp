using RxOutlet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FillNewPrescription : ContentPage
    {
        public FillNewPrescription()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new FillNewPrescriptionViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new FillNewPrescriptionViewModel(Navigation);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
        }
    }
}