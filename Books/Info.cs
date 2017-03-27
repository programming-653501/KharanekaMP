using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*Статический класс Info отвечает за считывание 
 *и обновление информации в файле Report.txt*/

namespace Books
{
    public static class Info
    {
        public static uint overallNumberOfBooks { get; private set; }
        public static uint overallNumberOfSales { get; private set; }
        public static decimal overallCostOfBooks { get; private set; }
        public static uint overallNumberOfBooksSold { get; private set; }
        public static decimal overallIncome { get; private set; }
        static string[][] mas;

        static Info()
        {
            using (StreamReader rd = new StreamReader(@"Report.txt", Encoding.GetEncoding(1251)))
            {
                mas = new string[5][];
                for (int i = 0; i < 5; i++)
                {
                    mas[i] = rd.ReadLine().Split(new char[] { ' ' });
                }
                overallCostOfBooks = decimal.Parse(mas[1][mas[1].Length - 1]);
                overallIncome = decimal.Parse(mas[4][mas[4].Length - 1]);
                overallNumberOfBooks = UInt32.Parse(mas[0][mas[0].Length - 1]);
                overallNumberOfBooksSold = UInt32.Parse(mas[3][mas[3].Length - 1]);
                overallNumberOfSales = UInt32.Parse(mas[2][mas[2].Length - 1]);
            }        
        }

        public static void Refresh()
        {
            ArrayList a = new ArrayList(5); for (int i =0; i < 5; i++) { a.Add(2); }
            a[0] = overallNumberOfBooks = Book.OverallNumber;
            a[1] = overallCostOfBooks = Book.OverallCost;
            a[4] = overallIncome += Sales.OverallIncome;
            a[2] = overallNumberOfSales += Sales.OverallSales;
            a[3] = overallNumberOfBooksSold += Sales.OverallNumberOfBooks;
            Sales.CleanSessionData();

            using (StreamWriter sw = new StreamWriter(@"Report.txt", false, Encoding.GetEncoding(1251))) 
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < mas[i].Length - 1; j++)
                    {
                        sw.Write(mas[i][j] + ' ');
                    }
                    sw.Write(a[i]);
                    sw.WriteLine();
                }
            }
        }
    }
}
