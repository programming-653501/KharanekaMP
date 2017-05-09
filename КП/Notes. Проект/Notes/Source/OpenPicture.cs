using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Notes
{
    public partial class MainWindow
    {
        internal static void AttachedImage_FullSize(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
            Window imgWin = new Window();
            imgWin.ShowInTaskbar = false;
            Image img = new Image();
            img.Source = (sender as Image).Source;
            imgWin.Content = img;
            imgWin.MouseLeftButtonDown += ImgWin_MouseLeftButtonDown;
            imgWin.ShowActivated = true;
            imgWin.Show();
        }

        private static void ImgWin_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (sender as Window).Close();
        }
    }
}
