using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*Класс BookList отвечает за работу с одноименным файлом.
 *Тут реализованы два статических метода:
 *GetBooks(out Book) - открывает и считывает файл в динамический двунаправленный
 *список.
 *RefreshBooks(List<Book>) - переписывает файл BookList.txt*/




namespace Books
{
    public static class BookList
    {
        public static void GetBooks(out Book b)
        {
            using (StreamReader rd = new StreamReader(@"BookList.txt", Encoding.GetEncoding(1251)))
            {
                b = new Book();
                string prevAuthor = "", prevName = "";
                rd.ReadLine();
                string[] data;
                while (!rd.EndOfStream)
                {
                    data = rd.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (data.Length == 6)
                    {
                        Book.Add(ref b, new OneBook { author = data[0], name = data[1], number = UInt32.Parse(data[2]), buyPrice = decimal.Parse(data[3]), sellPrice = decimal.Parse(data[4]), requisites = data[5] });
                        prevAuthor = data[0];
                        prevName = data[1];
                    }
                    else
                    {
                        Book.Add(ref b, new OneBook { author = prevAuthor, name = prevName, number = UInt32.Parse(data[0]), buyPrice = decimal.Parse(data[1]), sellPrice = decimal.Parse(data[2]), requisites = data[3] });
                    }
                }
            }
        }

        public static void RefreshBooks(List<Book> list)
        {
            using (StreamWriter sw = new StreamWriter(@"BookList.txt", false, Encoding.GetEncoding(1251)))
            {
                sw.WriteLine("author         name           number         buy price      sell price     req.");
                foreach (Book book in list)
                {
                    int i = 0;
                    sw.Write($"{book.Author,-15}{book.Name,-15}");
                    foreach (Pics p in book.pics)
                    {
                        if (i == 0)
                            sw.WriteLine($"{p.Number,-15}{p.BuyPrice,-15}{p.SellPrice,-15}{p.Requisites}");
                        else
                            sw.WriteLine("                              " + $"{p.Number,-15}{p.BuyPrice,-15}{p.SellPrice,-15}{p.Requisites}");
                        i++;
                    }
                }
            }
        }
    }
}
