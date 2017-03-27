using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Books;

namespace lab6._2._1
{
    partial class Program
    {
        public static void BuyBooks(ref List<Book> list)
        {
            Console.WriteLine("Введите информацию о заказе(через пробел)");
            Console.WriteLine("Автор Название Количество Цена покупки Цена продажи Реквизиты(ISBN-*****-*****)");
            Regex reg = new Regex(@"\w+ \w+ \d+ \d+ \d+ \S+");
            string s = Console.ReadLine();
            if (!reg.IsMatch(s))
                throw new Exception("Информация введена некорректно!");
            string[] data = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            list.Add(new OneBook { author = data[0], name = data[1], number = UInt32.Parse(data[2]), buyPrice = decimal.Parse(data[3]), sellPrice = decimal.Parse(data[4]), requisites = data[5] });

        }
    }
}
