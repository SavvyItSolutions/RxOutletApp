using Plugin.Media;
using Plugin.Media.Abstractions;
using RxOutlet.BusinessRules;
using RxOutlet.Common;
using RxOutlet.Entity;
using RxOutlet.Views.Popups;
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

        public FillNewPrescriptionViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                objRxOutletBR = new RxOutletBR();
                UserID = UserInfo.UserID;
            }
            catch (Exception ex)
            {
                DisplayPopUp.ClientError();
            }
        }

        #endregion

        #region Events

        private async void SelectCameraOrGallery()
        {
            try
            {
                await NavigationService.PushPopupAsync(Navigation, new CameraPopup());
                return;
                //if (isFirst)
                //{
                //    IsShow = true;
                //    isFirst = !isFirst;
                //}
                //else
                //{
                //    IsShow = false;
                //    isFirst = !isFirst;
                //}
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
                int count;
                //if (IsShow)
                //{
                //    IsShow = !IsShow;
                //    isFirst = !isFirst;
                //}
                
                await NavigationService.PopAllPopupAsync(Navigation);
                Message = Messages.ImgUploadedFail;

                IsBusy = true;
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) return;

                MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());

                if (file == null) return;

                IsBusy = true;
                count = await UploadImage(file);

                if (count == (int)StatusCode.Fail)
                {
                    Message = Messages.ImgUploadedFail;
                    //Remove
                    Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                    return;
                }
                else
                {
                    Message = Messages.ImgUploadedSuceess;
                    Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                }
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

        private async Task OpenGallery()
        {
            try
            {
                int count;
                
                await NavigationService.PopAllPopupAsync(Navigation);
                
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported) return;

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null) return;

                IsBusy = true;

                count = await UploadImage(file);

                if (count == (int)StatusCode.Fail)
                {
                    Message = Messages.ImgUploadedFail;
                    //Remove
                    Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                    return;
                }
                else
                {
                    Message = Messages.ImgUploadedSuceess;
                    Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                }
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

        private async Task SubmitClick()
        {
            int insertItemCount;
            try
            {
                IsBusy = true;
                Message = string.Empty;

                if (!DeviceInformation.CheckDeviceInternetAccess())
                {
                    await DisplayPopUp.NetWorkFailure();
                    return;
                }

                if (objPrescModel == null || string.IsNullOrEmpty(objPrescModel.UserID) || string.IsNullOrEmpty(objPrescModel.PhysicianName) || string.IsNullOrEmpty(objPrescModel.PhysicianNumber) || string.IsNullOrEmpty(objPrescModel.MedicationFor))
                {
                    Message = Messages.MandatoryFields;
                    //Remove
                    //Application.Current.MainPage.DisplayAlert("RxOutlet", Message, "OK");
                    return;
                }

                var res = await objRxOutletBR.UploadPrescription(objPrescModel);

                if (res.ErrorCode == (int)StatusCode.Success)
                {
                    Message = Messages.ImgUploadedSuceess;      
                }
                else
                {
                    Message = Messages.ImgUploadedFail;
                }                
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
        private async Task<int> UploadImage(MediaFile file)
        {
            objByteModel = new ByteArrayModel();
            Byte[] imageAsBytes = null;

            try
            {
                IsBusy = true;
                objByteModel.FileExtension = Path.GetExtension(file.Path);

                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    file.Dispose();
                    imageAsBytes = memoryStream.ToArray();
                }

                objByteModel.array = imageAsBytes;
                objByteModel.userid = UserID;

                return await objRxOutletBR.UploadProfilePic(objByteModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearFields()
        {
            //PhysicianName
        }
        #endregion

    }
}
