using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notes
{
    public partial class MainWindow
    {
        public static BitmapImage LoadImageFromFile(string filename)
        {
            using (var fs = File.OpenRead(filename))
            {
                var img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.DecodePixelWidth = (int)SystemParameters.PrimaryScreenWidth;
                img.StreamSource = fs;
                img.EndInit();
                return img;
            }
        }

        private void Note_Drop(object sender, DragEventArgs e)
        {
            if (sender is StackPanel)
            {
                e.Effects = DragDropEffects.Copy;
                var data = e.Data as DataObject;
                var imgList = new List<Image>();
                
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                try
                {
                    if (data.ContainsFileDropList())
                    {
                        files = data.GetFileDropList();
                        for (int j = 0; j < files.Count; j++)
                        {
                            imgList.Add(new Image());
                            imgList[imgList.Count - 1].Source = LoadImageFromFile(files[j]);
                            imgList[imgList.Count - 1].MouseLeftButtonDown += AttachedImage_FullSize;
                        }
                        
                    }



                    var grid = (((e.Source as TextBlock).Parent as Grid).Parent as StackPanel).Children[1] as Grid;
                    WrapPanel wp = grid.Children[1] as WrapPanel;

                    int i = wp.Children.Count;
                    int k = 0;

                    foreach (Image img in imgList)
                    {
                        img.Width = 100;
                        img.Height = 60;
                        img.AllowDrop = false;
                        wp.Children.Add(img);
                        ((grid.Parent as StackPanel).Children[2] as TextBlock).Text += "░" + files[k++];
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

       
    }
}
