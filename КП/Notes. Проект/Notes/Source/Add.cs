using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Notes
{
    public partial class MainWindow
    {
        /*Файл отвечает за добавление заметок по средствам нажатия "+"*/
        private void Add_Handler(object sender, RoutedEventArgs e)
        {
            if (Type.SelectedIndex == 0)
            {
                if (ActualNotes.Children.Count != 0)
                {
                    if ((ActualNotes.Children[0] as StackPanel).Children[0] is Label)
                    {
                        ActualNotes.Children.RemoveAt(0);
                        return;
                    }
                }
            }
            else
            {
                if (PermNotes.Children.Count != 0)
                {
                    if ((PermNotes.Children[0] as StackPanel).Children[0] is Label)
                    {
                        PermNotes.Children.RemoveAt(0);
                        return;
                    }
                }
            }

            TextBox newNoteName = new TextBox();
            TextBox newNoteCaption = new TextBox();
            TextBox days = new TextBox();
            StackPanel addPanel = new StackPanel();
            Button addNoteButton = new Button();
            Grid buttonGrid = new Grid();
            Label header = new Label();
            Label underHeader = new Label();
            Label date = new Label();
            Label daysMark = new Label();
            


            header.Content = "Заголовок";
            addPanel.Children.Add(header);

            newNoteName.MaxLength = 25;
            addPanel.Children.Add(newNoteName);

            underHeader.Content = "Описание";
            underHeader.Margin = new Thickness(0, 2, 0, 0);
            addPanel.Children.Add(underHeader);
            

            newNoteCaption.TextWrapping = TextWrapping.Wrap;
            newNoteCaption.MinHeight = 50;
            addPanel.Children.Add(newNoteCaption);

            if (Type.SelectedIndex == 0)
            {
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };

                date.Content = "Срок";
                date.Margin = new Thickness(0, 2, 0, 0);
                sp.Children.Add(date);

                days.MaxLength = 4;
                days.Width = 50;
                days.Height = 15;
                sp.Children.Add(days);

                daysMark.Content = "дней";
                daysMark.Margin = new Thickness(2, 2, 0, 0);
                sp.Children.Add(daysMark);
                
                
                addPanel.Children.Add(sp);
            }

            buttonGrid.Children.Add(addNoteButton);
            addNoteButton.Content = "Добавить";
            addNoteButton.IsDefault = true;
            addNoteButton.Click += AddNote_Click;
            addNoteButton.Margin = new Thickness(0, 3, 0, 8);
            addNoteButton.HorizontalAlignment = HorizontalAlignment.Right;
            addPanel.Children.Add(buttonGrid);

            if (Type.SelectedIndex == 0)
                ActualNotes.Children.Insert(0, addPanel);
            else
                PermNotes.Children.Insert(0, addPanel);

                newNoteName.Focus();
            
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Note newNote = new Note();
            UIElementCollection marks = Type.SelectedIndex == 0 ? (ActualNotes.Children[0] as StackPanel).Children : (PermNotes.Children[0] as StackPanel).Children;

            TextBox tb = marks[1] as TextBox;

            newNote.Name = tb.Text;

            if (Type.SelectedIndex == 0)
                tb = (marks[4] as StackPanel).Children[1] as TextBox;
            else
                tb.Text = "";

            if (tb.Text != "")
            {
                try
                {
                    newNote.Days = Int32.Parse(tb.Text);
                    newNote.type = Notes.Type.Actual;
                }
                catch (Exception)
                {
                    newNote = null;
                    MessageBox.Show("Введите число дней");
                    return;
                }
            }
            else
                newNote.type = Notes.Type.Permanent;


            tb = marks[3] as TextBox;

            newNote.Descr = tb.Text;

            if (Type.SelectedIndex == 0)
                ActualNotes.Children.RemoveAt(0);
            else
                PermNotes.Children.RemoveAt(0);

            if (newNote.Name == "" && newNote.Descr == "")
            {
                newNote = null;
                Adder.IsEnabled = true;
                return;
            }
            

            Note.Add(newNote);
            if (newNote.type == Notes.Type.Actual)
                ActualNotes.Children.Insert(0, Note.NoteVisualize(newNote));
            else
                PermNotes.Children.Insert(0, Note.NoteVisualize(newNote));

            Adder.IsEnabled = true;
        }

        private void Adder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.N) && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                e.Handled = true;
                Add_Handler(sender, new RoutedEventArgs());
            }
        }

    }
}
