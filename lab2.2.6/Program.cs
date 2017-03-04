using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._2._2._6
{
    class Program
    {
        static long n = 1;

        static long Factorial(long x) => (x == 0) ? 1 : x * Factorial(x - 1);

        static double HandMadeSin(double x, double eps, double znach = 0)
        {
            znach += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / Factorial(2 * n - 1);
            if (Math.Pow(x, 2 * n - 1) / Factorial(2 * n - 1) < eps)
                return znach;
            else
            {
                n++;
                return HandMadeSin(x, eps, znach);
            }
        }

        static void Main(string[] args)
        {
            double a, eps;

            Console.Write("Введите угол в градусах: ");
            while(!Double.TryParse(Console.ReadLine(), out a))
                Console.WriteLine("Входная строка имеет неверный формат");

            Console.Write("Введите точность: ");
            while (!Double.TryParse(Console.ReadLine(), out eps))
                Console.WriteLine("Входная строка имеет неверный формат");

            Console.WriteLine(Math.Sin(a / 90 * Math.Acos(0)));
            Console.WriteLine(HandMadeSin(a/90*Math.Acos(0), eps));
            Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}
