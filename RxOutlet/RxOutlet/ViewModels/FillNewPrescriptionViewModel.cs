using Plugin.Media;
using Plugin.Media.Abstractions;
using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Entity;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class FillNewPrescriptionViewModel : BaseViewModel
    {
        #region Variables

        private bool isFirst = true;
        private RxOutletBR objRxOutletBR = null;
        private UploadPrescriptionModel objPrescModel = new UploadPrescriptionModel();
        private ByteArrayModel objByteModel = null;

        #endregion

        #region Properties

        public string PhysicianName
        {
            get => objPrescModel.PhysicianName;
            set => objPrescModel.PhysicianName = value;
        }

        public string PhysicianNumber
        {
            get => objPrescModel.PhysicianNumber;
            set => objPrescModel.PhysicianNumber = value;
        }

        public string MedicationFor
        {
            get => objPrescModel.MedicationFor;
            set => objPrescModel.MedicationFor = value;
        }

        public string UserID
        {
            get => objPrescModel.UserID;
            set => objPrescModel.UserID = value;
        }

        public Command OpenCameraCommand
        {
            get => new Command(async () => await OpenCamera());
        }

        public Command OpenGalleryCommand
        {
            get => new Command(async () => await OpenGallery());
        }

        public Command SelectCameraOrGalleryCommand
        {
            get => new Command(() => SelectCameraOrGallery());
        }

        public Command SubmitClickCommand
        {
            get => new Command(async () => await SubmitClick());
        }

        private ImageSource img;
        public ImageSource Img
        {
            get => img;
            set { SetProperty(ref img, value); }
        }

        private bool isShow = false;
        public bool IsShow
        {
            get => isShow;
            set { SetProperty(ref isShow, value); }
        }

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
                DisplayPopUp.ClientError();
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
                DisplayPopUp.ClientError();
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

                MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());

                if (file == null) return;

                await UploadImage(file);

                Message = Messages.ImgUploadedSuceess;
            }
            catch (Exception ex)
            {
                DisplayPopUp.ClientError();
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

                await UploadImage(file);

                Message = Messages.ImgUploadedSuceess;
            }
            catch (Exception ex)
            {
                DisplayPopUp.ClientError();
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
                    await DisplayPopUp.NetWorkFailure();
                    return;
                }

                if (objPrescModel == null && string.IsNullOrEmpty(objPrescModel.UserID) && string.IsNullOrEmpty(objPrescModel.PhysicianName) && string.IsNullOrEmpty(objPrescModel.PhysicianNumber) && string.IsNullOrEmpty(objPrescModel.MedicationFor))
                {
                    Message = Messages.MandatoryFields;
                    return;
                }

                insertItemCount = await objRxOutletBR.UploadPrescription(objPrescModel);

                if (insertItemCount > 0)
                    Message = "Success";
                else
                    Message = "Failur";

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                DisplayPopUp.ClientError();
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// UploadImage
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task UploadImage(MediaFile file)
        {
            objByteModel = new ByteArrayModel();
            Byte[] imageAsBytes = null;

            try
            {
                objByteModel.FileExtension = Path.GetExtension(file.Path);

                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    file.Dispose();
                    imageAsBytes = memoryStream.ToArray();
                }

                objByteModel.Array = imageAsBytes;
                objByteModel.UserID = UserID;

                int a = await objRxOutletBR.UploadProfilePic(objByteModel);
            }
            catch (Exception ex)
            {
                DisplayPopUp.ClientError();
            }
        }

        #endregion

    }
}
