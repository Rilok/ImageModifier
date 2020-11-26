using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using ImageProcessing;

namespace ImageProcessingTest
{
    [TestClass]
    public class LockBitsTest
    {
        private ImageProcessLockBits imgLockBits;
        private ImageProcess imgGetPix;
        private Bitmap testBitmap;
        private Color testColor;


        [TestInitialize]
        public void init()
        {
            imgLockBits = new ImageProcessLockBits();
            imgGetPix = new ImageProcess();
            string workingDir = Environment.CurrentDirectory;
            string projectDir = Directory.GetParent(workingDir).Parent.FullName;
            testBitmap = new Bitmap($@"{projectDir}\Images\placeholder.png");
            testColor = Color.Empty;
        }

        [TestMethod]
        public void ImgProc_LockBits_CheckIfChangedToRed()
        {
            Color expectedColor = Color.FromArgb(0xFF0000);

            imgLockBits.LockBits(testBitmap);
            testColor = imgLockBits.GetPixel(0, 0);
            Color newColor = imgLockBits.changeColor(testColor);

            Assert.AreEqual(expectedColor, newColor);
        }

        [TestMethod]
        public void ImgProc_LockBits_CheckIfTheSamePixelData()
        {
            imgLockBits.LockBits(testBitmap);
            var testLockBits = imgLockBits.GetPixel(1, 1);
            imgLockBits.UnlockBits(testBitmap);
            var testGetPix = testBitmap.GetPixel(1, 1);

            Assert.AreEqual(testLockBits, testGetPix);
        }


        [TestMethod]
        public void ImgProc_LockBits_CompareTwoMethods()
        {
            imgLockBits.source = testBitmap;
            var resultLockBits = imgLockBits.ToMainColorsBeta();

            imgGetPix.bitmap = testBitmap;
            var resultGetPix = imgGetPix.ToMainColors();

            Assert.AreEqual(resultLockBits, resultGetPix);
        }

        [TestCleanup]
        public void clean()
        {
            imgLockBits = null;
            imgGetPix = null;
            testBitmap = null;
            testColor = Color.Empty;
        }
    }
}
