using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Методы расширения для List<Book> добавление книг, продажа, инициализация двунаправленным динамическим списком*/
namespace Books
{
    public static class ListExtensions
    {
        public static void Add(this List<Book> list, OneBook newBook)
        {
            Book.OverallNumber += newBook.number;
            Book.OverallCost += newBook.sellPrice * newBook.number;
            list.Add(new Book() + newBook);
            list.Sort();
            BookList.RefreshBooks(list);
            Info.Refresh();
        }

        public static void Sell(this List<Book> list, string bookToSell, uint number)
        {
            bool found = false;
            int place = 0;
            decimal sum;
            decimal clearsum;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == bookToSell)
                {
                    place = i;
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Книга не найдена!");
                return;
            }

            if (list[place].Number == number)
            {
                (list[place], sum, clearsum) = list[place] - number;
                Console.WriteLine($"Все книги успешно проданы! На сумму {sum}, прибыль: {clearsum}");

                Book.OverallCost -= sum;
                Book.OverallNumber -= number;

                Sales.Write(list[place], number, sum, clearsum);

                list.RemoveAt(place);
            }
            else if (list[place].Number < number)
            {
                Console.WriteLine("К сожалению, у нас нет столько книг, осталось " + list[place].Number);
            }
            else
            {
                (list[place], sum, clearsum) = list[place] - number;

                Book.OverallCost -= sum;
                Book.OverallNumber -= number;

                Console.WriteLine($"Книги успешно проданы! На сумму {sum}, прибыль: {clearsum}, осталось: {list[place].Number}");
                Sales.Write(list[place], number, sum, clearsum);
            }
            BookList.RefreshBooks(list);
            Info.Refresh();
        }

        public static void Initialize(this List<Book> list, Book b)
        {
            do
            {
                list.Add(b);
                b = b.next;
            }
            while (b != null);
            list.Sort();
        }
    }
}
