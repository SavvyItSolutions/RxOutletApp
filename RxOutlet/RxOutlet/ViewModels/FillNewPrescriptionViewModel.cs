using Plugin.Media;
using Plugin.Media.Abstractions;
using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class FillNewPrescriptionViewModel : ViewModelBase
    {
        #region Variables

        private bool isFirst = true;
        private RxOutletBR objRxOutletBR = null;
        private string UserID = string.Empty;

        #endregion

        #region Properties

        private ImageSource img;

        public ImageSource Img
        {
            get => img;
            set { SetProperty(ref img, value); }
        }
        
        private bool  isShow= false;
        public bool IsShow
        {
            get => isShow;
            set { SetProperty(ref isShow, value); }
        }

        private string physicianName = string.Empty;
        public string PhysicianName
        {
            get => physicianName;
            set { SetProperty(ref physicianName, value); }
        }

        private string physicianNumber = string.Empty;
        public string PhysicianNumber
        {
            get => physicianNumber;
            set { SetProperty(ref physicianNumber, value); }
        }

        private string medicationFor = string.Empty;
        public string MedicationFor
        {
            get => medicationFor;
            set { SetProperty(ref medicationFor, value); }
        }

        public Command OpenCameraCommand { get => new Command(async () => await OpenCamera()); }
        public Command OpenGalleryCommand { get => new Command(async () => await OpenGallery()); }
        public Command SelectCameraOrGalleryCommand { get => new Command(() => SelectCameraOrGallery()); }
        public Command SubmitClickCommand { get => new Command(async() => await SubmitClick()); }
        
        #endregion

        #region Constractor

        public FillNewPrescriptionViewModel(INavigation navigation, string userID) : base(navigation)
        {
            try
            {
                objRxOutletBR = new RxOutletBR();
                UserID = userID;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.ClientError, YesNO.OK.ToString());
            }
        }

        #endregion

        #region Events

        private void SelectCameraOrGallery()
        {
            try
            {
                if (isFirst)
                {
                    IsShow = true;
                    isFirst = !isFirst;
                }
                else
                {
                    IsShow = false;
                    isFirst = !isFirst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private async Task OpenCamera()
        {
            try
            {
                if (IsShow)
                {
                    IsShow = !IsShow;
                    isFirst = !isFirst;
                }

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) return;
                
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());

                var path = file.Path;
                string extension = Path.GetExtension(path);

                if (file == null) return;
                Byte[] imageAsBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    file.Dispose();
                    imageAsBytes = memoryStream.ToArray();                    
                }
                int a = await objRxOutletBR.UploadProfilePic(imageAsBytes);
                //    new ByteArrayModel()
                //{ array = imageAsBytes});

                if (a > 0)
                    await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.ImgUploadedSuceess, YesNO.OK.ToString());
                //Img = ImageSource.FromStream(() => file.GetStream());

                Message = Messages.ImgUploadedSuceess;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.ClientError, YesNO.OK.ToString());
            }
        }

        private async Task OpenGallery()
        {
            try
            {
                if (IsShow)
                {
                    IsShow = !IsShow;
                    isFirst = !isFirst;
                }

                Img = string.Empty;

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported) return;

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null) return;

                Byte[] imageAsBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    file.Dispose();
                    imageAsBytes = memoryStream.ToArray();
                    
                }
                var path = file.Path;
                string extension = Path.GetExtension(path);

                int a = await objRxOutletBR.UploadProfilePic(imageAsBytes);
                    await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.ImgUploadedSuceess, YesNO.OK.ToString());

                //Img = ImageSource.FromStream(() => file.GetStream());
                Message = Messages.ImgUploadedSuceess;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.ClientError, YesNO.OK.ToString());                
            }
        }

        private async Task SubmitClick()
        {
            int insertItemCount;
            try
            {
                IsBusy = true;

                if (!DeviceInformation.CheckDeviceInternetAccess())
                {
                    await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.CheckNetConnection, YesNO.OK.ToString());
                    return;
                }

                insertItemCount = await objRxOutletBR.UploadPrescription(new UploadPrescriptionModel()
                {
                    PhysicianName = PhysicianName,
                    PhysicianNumber = PhysicianNumber,
                    MedicationFor = medicationFor,
                    UserID = UserID
                });

                if (insertItemCount > 0)
                    Message = "Success";
                else
                    Message = "Failur";

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert(Messages.ProductName, Messages.ClientError, YesNO.OK.ToString());
            }
        }

        #endregion

    }
}
