using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using ImageProcessing;

namespace ImageProcessingTest
{
    [TestClass]
    public class GetPixelTest
    {
        private Bitmap testBitmap;
        private Color testColor;
        private ImageProcess imgProcess;
        private string projectDirectory;
        [TestInitialize]
        public void prepare()
        {
            imgProcess = new ImageProcess();
            string workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            testBitmap = new Bitmap($@"{projectDirectory}\Images\placeholder.png");
            testColor = Color.Empty;

        }
        [TestMethod]
        public void ImgProc_GetPixel_CheckIfChangedToRed()
        {
            Color expectedColor = Color.FromArgb(0xFF0000);

            testColor = testBitmap.GetPixel(0, 0);
            Color newColor = imgProcess.changeColor(testColor);

            Assert.AreEqual(expectedColor, newColor);
        }

        [TestMethod]
        public void ImgProc_GetPixel_CheckIfMaxIsRed()
        {
            int redMax = 0xEE;

            Color testColor = Color.FromArgb(0xEECFAE);
            int testMax = imgProcess.maxColor(testColor);

            Assert.AreEqual(redMax, testMax);
        }

        [TestMethod]
        public void ImgProc_GetPixel_CheckIfMaxIsGreen()
        {
            int greenMax = 0xED;

            Color testColor = Color.FromArgb(0x80EDCC);
            int testMax = imgProcess.maxColor(testColor);

            Assert.AreEqual(greenMax, testMax);
        }

        [TestMethod]
        public void ImgProc_GetPixel_CheckIfMaxIsBlue()
        {
            int blueMax = 0xCA;

            Color testColor = Color.FromArgb(0xAABBCA);
            int testMax = imgProcess.maxColor(testColor);

            Assert.AreEqual(blueMax, testMax);
        }

        [TestMethod]
        public void ImgProc_GetPixel_CheckIfImageLoaded()
        {
            imgProcess.bitmap = null;
            imgProcess.LoadImage($@"{projectDirectory}/Images/placeholder.png");

            Assert.IsNotNull(imgProcess.bitmap);
        }

        [TestCleanup]
        public void clean()
        {
            testBitmap = null;
            imgProcess = null;
            testColor = Color.Empty;
        }
    }
}
