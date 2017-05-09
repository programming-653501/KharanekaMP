using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Обработчики открытия и закрытия программы. Происходит первоначальная инициализация окна и запись заметок 
        // перед закрытием программы.
        public MainWindow()
        {
            InitializeComponent();

            //Загрузка настроек.
            MyFile.LoadSettings();

            // Инициализация списка заметок из файла.
            Note.SetList(MyFile.Open());

            // Осветление цвета оформления (при необходимости)
            Color windowColor = SystemParameters.WindowGlassColor;
            if (windowColor.R < 200 && windowColor.G < 200 && windowColor.B < 200)
            {
                windowColor.R = (byte)(windowColor.R * 1.2);
                windowColor.G = (byte)(windowColor.G * 1.2);
                windowColor.B = (byte)(windowColor.B * 1.2);
            }

            SolidColorBrush windowBrush = new SolidColorBrush(windowColor);
            //---------------------------------------------------------------------------------------


            //Добавление стиля, связанного с оформлением виндоус.------------------------------------
            Style backStyle = new Style();
            backStyle.Setters.Add(new Setter(BackgroundProperty, windowBrush));
            backStyle.Setters.Add(new Setter(FontFamilyProperty, new FontFamily("Century Gothic MS")));
            this.Resources.Add("Color", backStyle);
            Actual.Style = Permanent.Style = Type.Style = Adder.Style = Closer.Style = Settings.Style = backStyle;

            //----------------------------------------------------------------------------------------

            

            // Получение копии списка заметок.
            List<Note> notes = Note.GetList();

            // Добавление всех заметок в окно (кроме устаревших). Удаление устаревших заметок.
            List<int> toRemove = new List<int>();

            int i = 0;
            if (notes != null)
                foreach (Note note in notes)
                {
                    if (note.type == Notes.Type.Actual)
                    {
                        if(DateTime.Now >= note.CollapseDate)
                        {
                            toRemove.Add(i);
                            continue;
                        }
                        ActualNotes.Children.Add(Note.NoteVisualize(note));
                    }
                    else
                    {
                        PermNotes.Children.Add(Note.NoteVisualize(note));
                    }
                    
                    i++;
                }
            else
                Note.SetList(new List<Note>());
            
            foreach(int n in toRemove)
                notes.RemoveAt(n);
            //-----------------------------------------------------------------------------

            ActualNotes.AddHandler(StackPanel.DropEvent, new DragEventHandler(Note_Drop));
            ActualNotes.AllowDrop = true;
            PermNotes.AddHandler(StackPanel.DropEvent, new DragEventHandler(Note_Drop));
            PermNotes.AllowDrop = true;
            //Замена списка заметок с учетом устаревших заметок.
            Note.SetList(notes);
        }


        private void Window_close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Добавление в новый список заметок с учетом измененного в ходе использования программы
            // содержания и их количества отдельно для постоянных и временных заметок.
            MyFile.SaveSettings(new SettingsInfo());
            List<Note> list = new List<Note>();



            foreach (object obj in ActualNotes.Children)
            {
                if (!((obj as StackPanel).Children[0] is Grid))
                    continue;

                Note item = new Note()
                {
                    Name = (((obj as StackPanel).Children[0] as Grid).Children[0] as TextBlock).Text,
                    Descr = (((obj as StackPanel).Children[1] as Grid).Children[0] as TextBox).Text
                };

                if ((obj as StackPanel).Children.Count > 2)
                    item.bmi = (string)((obj as StackPanel).Children[2] as TextBlock)?.Text;

                

                foreach (Note note in Note.GetList())
                {
                    if (note.Name == item.Name)
                    {
                        note.bmi = item.bmi;
                        note.Descr = item.Descr;
                        item = note;
                        list.Add(item);
                        break;
                    }
                }

            }
            foreach (object obj in PermNotes.Children)
            {
                Note item = new Note()
                {
                    Name = (((obj as StackPanel).Children[0] as Grid).Children[0] as TextBlock).Text,
                    Descr = (((obj as StackPanel).Children[1] as Grid).Children[0] as TextBox).Text
                };

                if ((obj as StackPanel).Children.Count > 2)
                    item.bmi = (string)((obj as StackPanel).Children[2] as TextBlock)?.Text;


                foreach (Note note in Note.GetList())
                {
                    if (note.Name == item.Name)
                    {
                        note.bmi = item.bmi;
                        note.Descr = item.Descr;
                        item = note;
                        list.Add(item);
                        break;
                    }
                }

            }

            // Замена списка и сохранение в файл.

            Note.SetList(list);

            MyFile.Save(Note.GetList());
        }

       
        
        private void ToolBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            this.DragMove();
        }

        

        

        

        
    }
}
