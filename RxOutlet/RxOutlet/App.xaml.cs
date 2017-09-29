using Xamarin.Forms;
using RxOutlet.Views.Login;
using RxOutlet.Views.Menu;

namespace RxOutlet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Welcome());
           // MainPage = new RxOutletMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
