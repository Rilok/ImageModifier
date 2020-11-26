using System;
using System.Windows;
using System.Windows.Media.Imaging;
using ImageProcessing;
using Microsoft.Win32;

namespace ImageModifier
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (op.ShowDialog() == true)
            {
                ImgBox.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var currImage = new ImageProcess();
            currImage.LoadImage(ImgBox.Source.ToString());
            Benchmark.Start();
            var newImage = currImage.ToMainColors();
            Benchmark.End();
            Time.Text = Benchmark.GetSeconds().ToString();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save a picture";
            sfd.Filter = "Png|*.png|Jpg|*.jpg;*.jpeg|Bmp|*.bmp";
            if (sfd.ShowDialog() == true)
            {
                newImage.Save(sfd.FileName);
                ImgBox.Source = new BitmapImage(new Uri(sfd.FileName));
            }
        }

        private void btnSaveSec_Click(object sender, RoutedEventArgs e)
        {
            var currImage = new ImageProcessLockBits();
            currImage.LoadImageBeta(ImgBox.Source.ToString());
            Benchmark.Start();
            var newImage = currImage.ToMainColorsBeta();
            Benchmark.End();
            Time.Text = Benchmark.GetSeconds().ToString();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save a picture";
            sfd.Filter = "Png|*.png|Jpg|*.jpg;*.jpeg|Bmp|*.bmp";
            if (sfd.ShowDialog() == true)
            {
                newImage.Save(sfd.FileName);
                ImgBox.Source = new BitmapImage(new Uri(sfd.FileName));
            }
        }

        private async void btnSaveAsync_Click(object sender, RoutedEventArgs e)
        {
            var currImage = new ImageProcess();
            currImage.LoadImage(ImgBox.Source.ToString());
            var newImage = await currImage.ToMainColorsAsync();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save a picture";
            sfd.Filter = "Png|*.png|Jpg|*.jpg;*.jpeg|Bmp|*.bmp";
            if (sfd.ShowDialog() == true)
            {
                newImage.Save(sfd.FileName);
                ImgBox.Source = new BitmapImage(new Uri(sfd.FileName));
            }
        }
    }
}
