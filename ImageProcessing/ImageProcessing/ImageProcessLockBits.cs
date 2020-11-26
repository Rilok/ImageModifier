using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageProcessing
{
    public class ImageProcessLockBits
    {
        public Bitmap source { get; set; }
        IntPtr Iptr = IntPtr.Zero;
        private BitmapData imgData = null;

        public byte[] imgPixels { get; set; }
        public int imgDepth { get; set; }
        public int imgWidth { get; set; }
        public int imgHeight { get; set; }

        public void LockBits(Bitmap source)
        {
            try
            {
                imgWidth = source.Width;
                imgHeight = source.Height;

                int pixelCount = imgWidth * imgHeight;

                Rectangle rect = new Rectangle(0, 0, imgWidth, imgHeight);

                imgDepth = Bitmap.GetPixelFormatSize(source.PixelFormat);

                if (imgDepth != 24 && imgDepth != 32)
                {
                    throw new ArgumentException("Funkcja wspiera tylko obrazy w formacie 24 i 32 bpp.");
                }

                imgData = source.LockBits(rect, ImageLockMode.ReadWrite, source.PixelFormat);

                int step = imgDepth / 8;
                imgPixels = new byte[pixelCount * step];
                Iptr = imgData.Scan0;

                Marshal.Copy(Iptr, imgPixels, 0, imgPixels.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UnlockBits(Bitmap source)
        {
            try
            {
                Marshal.Copy(imgPixels, 0, Iptr, imgPixels.Length);
                source.UnlockBits(imgData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;

            int cCount = imgDepth / 8;

            int i = ((y * imgWidth) + x) * cCount;

            if (i > imgPixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (imgDepth == 24)
            {
                byte blue = imgPixels[i];
                byte green = imgPixels[i + 1];
                byte red = imgPixels[i + 2];
                clr = Color.FromArgb(red, green, blue);
            }

            if (imgDepth == 32)
            {
                byte blue = imgPixels[i];
                byte green = imgPixels[i + 1];
                byte red = imgPixels[i + 2];
                byte alpha = imgPixels[i + 3];
                clr = Color.FromArgb(alpha, red, green, blue);
            }

            return clr;
        }

        public void SetPixel(int x, int y, Color color)
        {
            int cCount = imgDepth / 8;

            int i = ((y * imgWidth) + x) * cCount;

            if (imgDepth == 24)
            {
                imgPixels[i] = color.B;
                imgPixels[i + 1] = color.G;
                imgPixels[i + 2] = color.R;
            }

            if (imgDepth == 32)
            {
                imgPixels[i] = color.B;
                imgPixels[i + 1] = color.G;
                imgPixels[i + 2] = color.R;
                imgPixels[i + 3] = color.A;
            }
        }

        public void LoadImageBeta(string location)
        {
            try
            {
                if (location.Contains("file:///"))
                {
                    source = new Bitmap($@"{location.Substring(8)}");
                }
                else
                {
                    source = new Bitmap($@"{location}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
        }

        public Bitmap ToMainColorsBeta()
        {
            ImageProcessLockBits lockBitmap = new ImageProcessLockBits();
            lockBitmap.LockBits(source);

            for (int x = 0; x < lockBitmap.imgWidth; x++)
            {
                for (int y = 0; y < lockBitmap.imgHeight; y++)
                {
                    Color currPixel = lockBitmap.GetPixel(x, y);
                    Color newPixel = changeColor(currPixel);
                    lockBitmap.SetPixel(x, y, newPixel);
                }
            }
            lockBitmap.UnlockBits(source);
            return source;
        }

        public Color changeColor(Color pixelColor)
        {
            if (maxColor(pixelColor) == pixelColor.R)
                pixelColor = Color.FromArgb(0xFF0000);
            else if (maxColor(pixelColor) == pixelColor.G)
                pixelColor = Color.FromArgb(0x00FF00);
            else
                pixelColor = Color.FromArgb(0x0000FF);

            return pixelColor;
        }

        public int maxColor(Color pixelColor)
        {
            return Math.Max(pixelColor.R, Math.Max(pixelColor.G, pixelColor.B));
        }
    }
}
