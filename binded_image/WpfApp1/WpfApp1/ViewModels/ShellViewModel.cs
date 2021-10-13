using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Drawing.Imaging;

namespace WpfApp1.ViewModels
{
    public class ShellViewModel : Border
    {
        private string _imagePath = "/cells.png"; // Image Path
        private string _imageRot = "Rotation0";  // Image Rotation
        private ImageSource _loadedImage; // Image

        public ShellViewModel()
        {
            UpdateImageCommand = new DelegateCommand<object>(UpdateImageCommand, CanUpdatePictureCommand);
        }


        public string ImagePath // Image Path
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        public string ImageRot // Image Rotation
        {
            get
            {
                return _imageRot;
            }
            set
            {
                _imageRot = value;
            }
        }

        public ImageSource LoadedImage // Loaded Image
        {
            get
            {
                return _loadedImage;
            }
            set
            {
                _loadedImage = value;
            }
        }

        public ICommand UpdateImageCommand { get; private set; }
        private void OnUpdateImageCommand(object obj)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            if (OpenFileDialog.ShowDialog() == true)
            {
                //(listbox.SelectedItem as ContactManager.ViewModel.Contact).Photo = 
                //    LoadPhoto(OpenFileDialog.FileName);
                Stream reader = File.OpenRead(OpenFileDialog.FileName);
                System.Drawing.Image photo = System.Drawing.Image.FromStream((Stream)reader);

                MemoryStream finalStream = new MemoryStream();
                photo.Save(finalStream, ImageFormat.Png);

                // translate to image source
                PngBitmapDecoder decoder = new PngBitmapDecoder(finalStream, BitmapCreateOptions.PreservePixelFormat,
                                                    BitmapCacheOption.Default);
                LoadedImage = decoder.Frames[0]; ;
            }


        }
    }
}
