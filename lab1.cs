using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Febonacci
{
    class Program
    {
        static int Get_i()
        {
            int a = 0;
            Console.Write("Введите целое число: ");
            if (!int.TryParse(Console.ReadLine(), out a))
                return -1;
            return a;
        }

        static string Generate(int n, string str = "", int a = 0, int b = 1)
        {
            int k;
            str += b.ToString();
            n -= b.ToString().Length;
            k = a + b;
            a = b;
            b = k;
            if (n <= 0)
                return str;
            else
                return Generate(n, str, a, b);
        }

        static char GetNum(int n)
        {
            return Generate(n)[n - 1];
        }

        static void Main(string[] args)
        {
            int a = -1;
            while (a < 0)
                a = Get_i();
            Console.WriteLine(GetNum(a));
            Console.ReadKey();
        }
    }
}
