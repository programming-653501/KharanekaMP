using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3._29
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(123);

            Console.Write("Введите размеронсть матрицы: ");
            int a;
            while(true)
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            int[,] mas = new int[a, a];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    mas[i, j] = rand.Next(100);
                    Console.Write("{0, -4}", mas[i,j]);
                }
                Console.WriteLine();
            }

            int[] sum = GetSums(mas, a);
            Console.WriteLine($"Верхняя: {sum[0]}, Правая: {sum[1]}, Нижняя: {sum[2]}, Левая: {sum[3]}");

            ChangeQuarters(ref mas, a);

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                    Console.Write("{0, -3} ", mas[i,j]);
                Console.WriteLine();
            }

            sum = GetSums(mas, a);
            Console.WriteLine($"Верхняя: {sum[0]}, Правая: {sum[1]}, Нижняя: {sum[2]}, Левая: {sum[3]}");

            Console.Read();

        }

        static void ChangeQuarters(ref int[,] mas, int dim)
        {
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                {
                    if (GetQuater(i, j, dim) == Quarter.left)
                        Swap(ref mas[i, j], ref mas[i, dim - j - 1]);
                    else if (GetQuater(i, j, dim) == Quarter.up)
                        Swap(ref mas[i, j], ref mas[dim - i - 1, j]);
                }
        }

        static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        static Quarter GetQuater(int i, int j, int dim)
        {
            if (i < j && i < dim - j - 1)
                return Quarter.up;
            else if (i < j && i > dim - j - 1)
                return Quarter.right;
            else if (i > j && i < dim - j - 1)
                return Quarter.left;
            else if (i > j && i > dim - j - 1)
                return Quarter.down;
            else return Quarter.diag;
        }

        static int[] GetSums(int[,] m, int dim)
        {
            int[] sums = new int[4];
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                    if (GetQuater(i, j, dim)!=Quarter.diag)
                        sums[(int)GetQuater(i, j, dim)] += m[i, j];
            return sums;
        }
    }

    enum Quarter
    {
        up = 0,
        left = 3,
        right = 1,
        down = 2,
        diag = 4
    }
}
