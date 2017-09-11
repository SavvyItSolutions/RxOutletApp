using Plugin.Media;
using Plugin.Media.Abstractions;
using RxOutlet.BusinessRules;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.ViewModels
{
    public class PrescriptionViewModel : ViewModelBase
    {
        #region Variables

        private bool isFirst = true;
        RxOutletBR signUpBR = null;

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

        public Command OpenCameraCommand { get; }
        public Command OpenGalleryCommand { get; }
        public Command SelectCameraOrGalleryCommand { get; }

        #endregion

        #region Constractor

        public PrescriptionViewModel(INavigation navigation) : base(navigation)
        {
            OpenCameraCommand = new Command(async () => await OpenCamera());
            OpenGalleryCommand = new Command(async () => await OpenGallery());
            SelectCameraOrGalleryCommand = new Command(() => SelectCameraOrGallery());
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

                if (file == null) return;

                Img = ImageSource.FromStream(() => file.GetStream());

                Message = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
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

                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    file.Dispose();
                    Byte[] imageAsBytes = memoryStream.ToArray();
                }

                Img = ImageSource.FromStream(() => file.GetStream());

                Message = "Updated Image Successfully";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
