using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


/*Статический класс Sales отвечает за записи в журнале, кроме того
 он также фиксирует закупки во время сеанса программы, метод CleanSessionData() 
 вызывается после записи информации в файл Report.txt(Info.Refresh())*/

namespace Books
{

    public static class Sales
    {
        public static decimal OverallIncome { get; private set; }
        public static uint OverallSales { get; private set; }
        public static uint OverallNumberOfBooks { get; private set; }


        public static void Write(Book b, uint number, decimal sum, decimal clear)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            OverallSales++;
            OverallIncome += clear;
            OverallNumberOfBooks += number;

            using (StreamWriter sw = new StreamWriter(@"Sales.txt", true, Encoding.GetEncoding(1251))) 
            {
                sw.WriteLine($"{dt.Hour}:{dt.Minute} {dt.Day}.{dt.Month}.{dt.Year}: Книга \"{b.Name}\" автора {b.Author} продана в количестве {number} на сумму {sum}. Доход от продажи: {clear}");
            }
        }

        public static void CleanSessionData()
        {
            OverallIncome = 0;
            OverallNumberOfBooks = 0;
            OverallSales = 0;
        }
    }
}
