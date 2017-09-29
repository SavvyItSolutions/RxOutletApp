using Xamarin.Forms;

namespace RxOutlet.Views.Login
{
    public class Prescription : TabbedPage
    {
        public Prescription(string userID)
        {
            Title = "Prescription";
            NavigationPage.SetHasNavigationBar(this, false);
            this.Children.Add(new FillNewPrescription(userID));
            this.Children.Add(new RefillYourPrescription());
            this.Children.Add(new TransferYourPrescription());
        }
        public Prescription()
        {
            Title = "Prescription";
            this.Children.Add(new FillNewPrescription());
            this.Children.Add(new RefillYourPrescription());
            this.Children.Add(new TransferYourPrescription());
        }
    }
}
