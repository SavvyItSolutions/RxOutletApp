using Xamarin.Forms;

namespace RxOutlet.Views.Login
{
    public class Prescription : TabbedPage
    {
        public Prescription(string userID)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.Children.Add(new FillNewPrescription(userID));
            this.Children.Add(new RefillYourPrescription());
            this.Children.Add(new TransferYourPrescription());
        }
    }
}
