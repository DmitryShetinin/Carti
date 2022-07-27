using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Windows.Controls.Image;

namespace Carti
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Bitmap[] bmpArr;
        public MainWindow()
        {
            InitializeComponent();
            string[] files = Directory.GetFiles(@"..\/..\/Resources/", "*.jpg", SearchOption.AllDirectories);


            bmpArr = new Bitmap[files.Length];
            for (int i = 0; i < bmpArr.Length; i++)
            {

                bmpArr[i] = new Bitmap(files[i]);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        int x = 0;
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        { using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0; BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit(); return bitmapimage; }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            while (x < 36)
            {
                Image image = new Image();
                image.Source = BitmapToImageSource(bmpArr[x]);
                image.MaxHeight = 150;
                image.MaxWidth = 150;
                if (x > 18)
                    StackPanel2.Children.Add(image);
                else
                    StackPanel1.Children.Add(image);
                x++;
            }
        }

        private void DeleteIndexMassiv(ref int[] massiv, int index)
        {
            int[] new_massiv = new int[massiv.Length-1];
            for(int i = 0; i < index; i++)
            {
                new_massiv[i] = massiv[i];
            }
            for(int i = index + 1; i < massiv.Length; i++){
                new_massiv[i-1] = massiv[i]; 
            }
            massiv = new_massiv;
        }
        int[] list;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            x = 0; 
            Random rand = new Random();
            list = new int[37];
            for (int i = 0; i <= 36; i++) { list[i] = i;  }
           
            StackPanel1.Children.Clear();
            StackPanel2.Children.Clear();
            while (list.Length != 0)
            {
                int s = rand.Next(0, list.Length-1);
                DeleteIndexMassiv(ref list, s);
                Image image = new Image();
                image.Source = BitmapToImageSource(bmpArr[s]);
              
                image.MaxHeight = 150;
                image.MaxWidth = 150;
                if (x > 18)
                    StackPanel2.Children.Add(image);
                else
                    StackPanel1.Children.Add(image);
                x++;
            }
        }
    }
}
