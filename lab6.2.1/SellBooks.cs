using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Books;

namespace lab6._2._1
{
    partial class Program
    {
        public static void SellBooks(ref List<Book> list)
        {
            Console.WriteLine("Введите название книги и количество экземпляров");
            Regex reg = new Regex(@"\S+ \d+");
            string s = Console.ReadLine();
            if (!reg.IsMatch(s))
                throw new Exception("Данные введены некорректно!");
            string[] mas = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            uint a = uint.Parse(mas[1]);
            list.Sell(mas[0], a);
        }
    }
}
