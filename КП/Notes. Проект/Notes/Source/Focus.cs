using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes
{
    public partial class MainWindow
    {
        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            // MainWin.Background = Brushes.White;
            MainWin.Opacity = 1.0;
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            // MainWin.Background = Brushes.Transparent;
            if (SettingsInfo.Transparency)
                MainWin.Opacity = 0.8;
        }
    }
}
