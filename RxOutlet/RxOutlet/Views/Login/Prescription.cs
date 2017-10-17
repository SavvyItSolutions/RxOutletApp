using Xamarin.Forms;

namespace RxOutlet.Views.Login
{
    public class Prescription : TabbedPage
    {
        public Prescription()
        {
            Title = "Prescription";
            NavigationPage.SetHasNavigationBar(this, false);
            this.Children.Add(new FillNewPrescription());
            this.Children.Add(new RefillYourPrescription());
            this.Children.Add(new TransferYourPrescription());
        }       
    }
}
