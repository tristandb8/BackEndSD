﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PanAndZoom
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RotateLeftClick(object sender, RoutedEventArgs e)
        {

            if (LoadedImage == null)
                return;

            //Create source
            BitmapImage bi = new BitmapImage();
            //BitmapImage properties must be in a BeginInit/EndInit block
            bi.BeginInit();
            bi.UriSource = new Uri(@"pack://application:,,/cells.png");
            //Set image rotation

            if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate0)
            {
                bi.Rotation = Rotation.Rotate270;
            }
            else if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate90)
            {
                bi.Rotation = Rotation.Rotate0;
            }
            else if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate180)
            {
                bi.Rotation = Rotation.Rotate90;
            }
            else if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate270)
            {
                bi.Rotation = Rotation.Rotate180;
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            bi.EndInit();
            //set image source
            LoadedImage.Source = bi;

        }

        private void RotateRightClick(object sender, RoutedEventArgs e)
        {

            if (LoadedImage == null)
                return;

            //Create source
            BitmapImage bi = new BitmapImage();
            //BitmapImage properties must be in a BeginInit/EndInit block
            bi.BeginInit();
            bi.UriSource = new Uri(@"pack://application:,,/cells.png");
            //Set image rotation

            if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate0)
            {
                bi.Rotation = Rotation.Rotate90;
            }
            else if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate90)
            {
                bi.Rotation = Rotation.Rotate180;
            }
            else if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate180)
            {
                bi.Rotation = Rotation.Rotate270;
            }
            else if (((BitmapImage)LoadedImage.Source).Rotation == Rotation.Rotate270)
            {
                bi.Rotation = Rotation.Rotate0;
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            bi.EndInit();
            //set image source
            LoadedImage.Source = bi;
        }
    }
}