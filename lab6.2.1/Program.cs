using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Books;

namespace lab6._2._1
{
    partial class Program
    {

        static void Main(string[] args)
        {

            BookList.GetBooks(out Book b);
            List<Book> list = new List<Book>();
            list.Initialize(b);
            bool isAlive = true;
            while (isAlive)
            {
                Console.WriteLine("1. Новая партия книг \n2. Продать книги \n3. Количество книг и их общая стоимость \n4. Количество сделанных заказов на книги \n5. Количество проданных книг \n6. Общая прибыль \n7. Список имеющихся книг \n8. История продаж \n9. Выход");
                try
                {
                    int a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();
                    switch(a)
                    {
                        case 1:
                            BuyBooks(ref list);
                            break;
                        case 2:
                            SellBooks(ref list);
                            break;
                        case 3:
                            Console.WriteLine("Общее количество книг: " + Info.overallNumberOfBooks);
                            Console.WriteLine("Общая стоимость книг: " + Info.overallCostOfBooks);
                            break;
                        case 4:
                            Console.WriteLine("Заказов сделано: " + Info.overallNumberOfSales);
                            break;
                        case 5:
                            Console.WriteLine("Книг продано: " + Info.overallNumberOfBooksSold);
                            break;
                        case 6:
                            Console.WriteLine("Общая прибыль: " + Info.overallIncome);
                            break;
                        case 7:
                            Console.WriteLine("Список книг: ");
                            using (StreamReader sr = new StreamReader("BookList.txt", Encoding.GetEncoding(1251)))
                            {
                                while(!sr.EndOfStream)
                                    Console.WriteLine(sr.ReadLine());
                            }
                            break;
                        case 8:
                            Console.WriteLine("История продаж: ");
                            using (StreamReader sr = new StreamReader("Sales.txt", Encoding.GetEncoding(1251)))
                            {
                                while (!sr.EndOfStream)
                                    Console.WriteLine(sr.ReadLine());
                            }
                            break;
                        case 9:
                            isAlive = false;
                            break;
                    }
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
