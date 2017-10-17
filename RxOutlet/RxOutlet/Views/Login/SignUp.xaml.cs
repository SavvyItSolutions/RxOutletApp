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

            //NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new SignUpViewModel(Navigation);
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return base.OnBackButtonPressed();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                this.Animate("Mypage", (s) => Layout(new Rectangle(((1 - s) * Width), Y, Width, Height)), 0, 100, Easing.SinIn);
                //this.Animate("Mypage", (s) => Layout(new Rectangle(X, (1 - s) * Height, Width, Height)), 0, 1000, Easing.SpringIn);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
           
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            this.Animate("mypage", (s) => Layout(new Rectangle((s * Width) * -1, Y, Width, Height)), 0, 100, Easing.Linear);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

        }
    }
}