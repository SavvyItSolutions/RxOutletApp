using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void LoginClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Login(false));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SignUpClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new SignUp());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}