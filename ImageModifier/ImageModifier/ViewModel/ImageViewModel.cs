using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using ImageModifier.Model;

namespace ImageModifier.ViewModel
{
    
    public class ImageViewModel
    {
        private ImageFile img = new ImageFile($@"{System.IO.Directory
            .GetParent(Environment.CurrentDirectory)
            .Parent.FullName}\Images\placeholder.png");
        public string Directory
        {
            get
            {
                return img.directory;
            }
            set
            {
                img.directory = value;

            }
        }
    }
}