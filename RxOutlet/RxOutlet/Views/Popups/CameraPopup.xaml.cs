using Rg.Plugins.Popup.Pages;
using RxOutlet.ViewModels;

namespace RxOutlet.Views.Popups
{
	public partial class CameraPopup : PopupPage
	{
		public CameraPopup ()
		{
			InitializeComponent ();
            BindingContext = new FillNewPrescriptionViewModel(Navigation);
        }
	}
}