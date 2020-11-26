using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using ImageModifier.Model;

namespace ImageModifier.ViewModel
{
    
    public class ImageViewModel
    {
        private ImageFile img = new ImageFile(@"C:\Users\\Rilok\\source\\repos\\ImageModifier\\ImageModifier\\Images\\placeholder.png");
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