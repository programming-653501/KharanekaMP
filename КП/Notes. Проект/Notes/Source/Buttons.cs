using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Notes
{
    public partial class MainWindow
    {
        private void Close_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings.IsEnabled = false;
            Window settings = new Window();
            settings.Width = 250;
            settings.Height = 120;
            settings.WindowStyle = WindowStyle.None;
            settings.ShowInTaskbar = false;
            settings.MouseLeftButtonDown += Settings_MouseLeftButtonDown;



            StackPanel sp = new StackPanel();
            settings.Content = sp;
            sp.Orientation = Orientation.Vertical;

            Label s = new Label();
            s.Content = "Настройки";
            s.HorizontalAlignment = HorizontalAlignment.Center;
            sp.Children.Add(s);

            CheckBox transp = new CheckBox();
            transp.Content = "Прозрачность при отведении курсора";
            transp.IsChecked = SettingsInfo.Transparency;
            sp.Children.Add(transp);


            CheckBox onTop = new CheckBox();
            onTop.Content = "Поверх всех окон";
            onTop.IsChecked = SettingsInfo.OnTop;
            sp.Children.Add(onTop);

            CheckBox inTB = new CheckBox();
            inTB.Content = "Показывать в панели задач";
            sp.Children.Add(inTB);
            inTB.IsChecked = SettingsInfo.InTaskbar;

            Button ok = new Button();
            ok.Content = "OK";
            ok.Width = 70;
            ok.Margin = new Thickness(0, 10, 5, 0);
            ok.HorizontalAlignment = HorizontalAlignment.Right;
            sp.Children.Add(ok);
            ok.Click += Ok_Click;

            settings.Show();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var settingsWindow = ((sender as Control).Parent as Panel).Parent as Window;
            var settingsPanel = settingsWindow.Content as StackPanel;

            settingsWindow.Close();
            if ((settingsPanel.Children[1] as CheckBox).IsChecked == true)
            {
                SettingsInfo.Transparency = true;
            }
            else
                SettingsInfo.Transparency = false;

            if ((settingsPanel.Children[2] as CheckBox).IsChecked == true)
            {
                SettingsInfo.OnTop = true;
                this.Topmost = true;
            }
            else
            {
                SettingsInfo.OnTop = false;
                this.Topmost = false;
            }

            if ((settingsPanel.Children[3] as CheckBox).IsChecked == true)
            {
                SettingsInfo.InTaskbar = true;
                this.ShowInTaskbar = true;
            }
            else
            {
                SettingsInfo.InTaskbar = false;
                this.ShowInTaskbar = false;
            }
            Settings.IsEnabled = true;

        }

        private void Settings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            (sender as Window).DragMove();
        }

    }
}
