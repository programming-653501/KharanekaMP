using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Notes
{
    // Перечисление с типом заметки.
    public enum Type
    {
        Actual,
        Permanent
    }

    /*Файл отвечает за хранение, запись и возврат информации о каждой из заметок,
     а также визуализацию*/

    // Объекты Note сериализуемы.
    [Serializable]
    public class Note
    {
        public Type type;
        public static List<Note> noteList = new List<Note>();
        public string Name { get; set; }
        public string Descr { get; set; }
        public DateTime CollapseDate { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string bmi;
        private int days;

        // Свойство. При изменении вычисляет дату уничтожения заметки.
        public int Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
                CollapseDate = DateTime.Now + new TimeSpan(value, 0, 0, 0);
            }
        }

        // Конструктор. Инициализирует поле даты создания заметки.
        public Note()
        {
            BirthDate = DateTime.Now;
        }

        // Деструктор.
        ~Note()
        {
            Name = null;
            Descr = null;
            Days = -1;
        }

        // Добавляет заметку в список заметок.
        public static void Add(Note note)
        {
            if (note != null)
            {
                if (noteList == null)
                    noteList = new List<Note>();
                noteList.Add(note);
            }
        }

        // Сеттер списка заметок.
        public static void SetList(List<Note> nl)
        {
            noteList = nl;
        }

        // Геттер списка заметок.
        public static List<Note> GetList()
        {
            return noteList;
        }


        // Визуализация заметки. Возвращает объект StackPanel с полным функционалом заметки.
        public static StackPanel NoteVisualize(Note note)
        {
            StackPanel full = new StackPanel();
            Grid header = new Grid();
            Grid content = new Grid();
            TextBox tb = new TextBox();
            TextBlock date = new TextBlock();
            TextBlock name = new TextBlock();
            Image delImg = new Image();
            Image attached = new Image();

            delImg.Source = (new System.Windows.Media.ImageSourceConverter().ConvertFromString("del.png")) as System.Windows.Media.ImageSource;

            tb.Opacity = 0.8;

            header.ColumnDefinitions.Add(new ColumnDefinition());
            header.ColumnDefinitions.Add(new ColumnDefinition());
            header.ColumnDefinitions.Add(new ColumnDefinition());

            header.ColumnDefinitions[2].MaxWidth = 50;
            header.ColumnDefinitions[2].MinWidth = 50;
            header.ColumnDefinitions[1].MaxWidth = 16;
            header.ColumnDefinitions[1].MinWidth = 16;
            header.Margin = new System.Windows.Thickness(1, 1, 1, 1);



            name.Text = note.Name;
            name.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            header.Children.Add(name);
            Grid.SetColumn(name, 0);

            header.Children.Add(delImg);
            delImg.MouseLeftButtonDown += DelImg_MouseLeftButtonDown;
            Grid.SetColumn(delImg, 1);


            date.Text = note.BirthDate.ToShortDateString();
            date.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            date.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            date.FontSize = 8;
            header.Children.Add(date);
            Grid.SetColumn(date, 2);
            

            

            tb.Text = note.Descr;
            tb.MinHeight = 50;
            tb.TextWrapping = System.Windows.TextWrapping.Wrap;

            content.RowDefinitions.Add(new RowDefinition());
            content.Children.Add(tb);
            Grid.SetRow(tb, 0);
            content.Visibility = System.Windows.Visibility.Collapsed;

            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Horizontal;
            content.RowDefinitions.Add(new RowDefinition());
            content.Children.Add(wp);
            Grid.SetRow(wp, 1);


            if (note.bmi != null && note.bmi != "")
            {
                var bmiCollection = note.bmi.Split(new char[] { '░' }, StringSplitOptions.RemoveEmptyEntries);
                var listImg = new List<Image>();


                for (int i = 0; i < bmiCollection.Length; i++)
                {
                    listImg.Add(new Image());
                    listImg[listImg.Count - 1].Width = 100;
                    listImg[listImg.Count - 1].Height = 60;
                    listImg[listImg.Count - 1].Source = MainWindow.LoadImageFromFile(bmiCollection[i]);
                    listImg[listImg.Count - 1].MouseLeftButtonDown += MainWindow.AttachedImage_FullSize;
                    wp.Children.Add(listImg[listImg.Count - 1]);
                }
            }

            TextBlock file = new TextBlock();
            file.Text = note.bmi;
            file.Visibility = System.Windows.Visibility.Collapsed;

            full.Children.Add(header);
            full.Children.Add(content);
            full.Children.Add(file);

            full.MouseLeftButtonDown += Full_MouseLeftButtonDown;

            return full;
        }


        // Удаление заметки.
        private static void DelImg_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StackPanel toDelete = (((sender as Image).Parent as Grid).Parent as StackPanel);
            (toDelete.Parent as StackPanel).Children.Remove(toDelete);
        }


        // Открытие и закрытие заметки.
        private static void Full_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            StackPanel full = sender as StackPanel;

            if (full.Children[1].Visibility == System.Windows.Visibility.Collapsed)
                full.Children[1].Visibility = System.Windows.Visibility.Visible;
            else
            {
                if (e.Source is TextBox)
                {
                    return;
                }

                full.Children[1].Visibility = System.Windows.Visibility.Collapsed;
                
            }
        }
    }
}
