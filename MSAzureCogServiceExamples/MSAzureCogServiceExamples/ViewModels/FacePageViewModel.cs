using MSAzureCogServiceExamples.Services;
using Plugin.Media;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MSAzureCogServiceExamples.ViewModels
{
    public class FacePageViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private ImageSource _selectedImage;
        public ImageSource SelectedImage
        {
            get { return _selectedImage; }
            set { SetProperty(ref _selectedImage, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        Stream selectedPicStream = null;

        public ICommand TakePhotoCommand { get; set; }
        public ICommand SelectPhotoCommand { get; set; }

        public FacePageViewModel()
        {
            TakePhotoCommand = new DelegateCommand(async () => await TakePhoto());
            SelectPhotoCommand = new DelegateCommand(async () => await SelectPhoto());
        }

        public async Task TakePhoto()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                Message = ":(No camera avaialble.";
                IsBusy = false;
                return;
            }
            try
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "FaceCheckPic.jpg",
                    SaveToAlbum = true
                });

                if (file == null)
                    return;

                SelectedImage = ImageSource.FromStream(() =>
                {
                    return file.GetStream();
                });
                selectedPicStream = file.GetStream();
                var faces = await FaceService.UploadAndDetectFaces(selectedPicStream);
                Message = "There are " + faces.Length.ToString() + " faces in picture";
                file.Dispose();

            }
            catch (Exception ex)
            {
                Message = "Uh oh :( Something went wrong \n " + ex.Message;
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task SelectPhoto()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Message = "Permission not granted to photos.";
                IsBusy = false;
                return;
            }
            try
            {
                var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);


                if (file == null)
                    return;
                SelectedImage = ImageSource.FromStream(() => file.GetStream());
                selectedPicStream = file.GetStream();
                var faces = await FaceService.UploadAndDetectFaces(selectedPicStream);
                Message = "There are " + faces.Length.ToString() + " faces in picture";
                file.Dispose();

            }
            catch (Exception ex)
            {
                Message = "Uh oh :( Something went wrong \n Error Message : " + ex.Message;
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
