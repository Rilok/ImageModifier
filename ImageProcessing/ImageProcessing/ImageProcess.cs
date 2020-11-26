using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageProcessing
{
    public class ImageProcess
    {
        public Bitmap bitmap { get; set; }

        public void LoadImage(string location)
        {
            try
            {
                if (location.Contains("file:///"))
                    bitmap = new Bitmap($@"{location.Substring(8)}");
                else
                    bitmap = new Bitmap($@"{location}");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
        }

        public Bitmap ToMainColors()
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    Color newColor = changeColor(pixelColor);
                    bitmap.SetPixel(x, y, newColor);
                }
            }

            return bitmap;
        }

        public async Task SetNewColor(int x, int y)
        {
            Color pixelColor = bitmap.GetPixel(x, y);
            Color newColor = changeColor(pixelColor);
            bitmap.SetPixel(x, y, newColor);
        }

        public async Task<Bitmap> ToMainColorsAsync()
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    await SetNewColor(x, y);
                }
            }

            return bitmap;
        }

        public Color changeColor(Color pixelColor)
        {
            if (maxColor(pixelColor) == pixelColor.R)
                pixelColor = Color.FromArgb(0, Color.FromArgb(0xFF0000));
            else if (maxColor(pixelColor) == pixelColor.G)
                pixelColor = Color.FromArgb(0, Color.FromArgb(0x00FF00));
            else
                pixelColor = Color.FromArgb(0, Color.FromArgb(0x0000FF));

            return pixelColor;
        }

        public int maxColor(Color pixelColor)
        {
            return Math.Max(pixelColor.R, Math.Max(pixelColor.G, pixelColor.B));
        }
    }
}
