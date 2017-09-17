
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.Common
{
    public static class DisplayPopUp
    {
        public static async Task NetWorkFailure()
        {
            await Application.Current.MainPage.DisplayAlert(ProductName.RxOutlet.ToString(), Messages.CheckNetConnection, YesNO.OK.ToString());
        }

        public static async void ClientError()
        {
            await Application.Current.MainPage.DisplayAlert(ProductName.RxOutlet.ToString(), Messages.ClientError, YesNO.OK.ToString());
        }
    }
}
