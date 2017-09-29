using RxOutlet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public Login(bool isShowMsg)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new LoginViewModel(Navigation);

            lblMsg.Text = isShowMsg ?
                "Thank you for Signing Up. We have sent an email to your authorized email address.Please activate." : 
                string.Empty;
        }
        

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return base.OnBackButtonPressed();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

        }
    }
}