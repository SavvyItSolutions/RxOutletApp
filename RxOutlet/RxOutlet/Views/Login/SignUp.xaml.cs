using RxOutlet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new SignUpViewModel(Navigation);
        }
    }
}