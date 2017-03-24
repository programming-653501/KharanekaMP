using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1_29
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            List<char[][]> chl = new List<char[][]>();

            Input(ref chl);

            ToPrint(ref chl);

            Console.WriteLine(new String('-', 20));

            Reverse(ref chl);

            ToPrint(ref chl);


            Console.ReadLine();
        }

        static void Reverse(ref List<char[][]> chl)
        {
            int sum = 0;

            foreach (char[][] mas in chl)
            {

                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = 0; j < mas[i].Length; j++)
                        sum += Convert.ToInt32(mas[i][j]);

                    if (sum % 2 == 0)
                        Array.Reverse(mas[i]);
                    sum = 0;
                }
            }

            
        }

        static void Input (ref List<char[][]> chl)
        {
            Random rand = new Random();
            int n;

            Console.Write("Введите количество матриц: ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0, a = 0, b = 0; i < n; i++)
            {
                Console.Write($"Количество строк {i + 1} матрицы: ");
                a = Int32.Parse(Console.ReadLine());
                Console.Write($"Количество столбцов {i + 1} матрицы: ");
                b = Int32.Parse(Console.ReadLine());

                chl.Add(new char[a][]);

                for (int j = 0; j < a; j++)
                    chl[i][j] = new char[b];  // Инициализация каждой строки матрицы.

                for (int j = 0; j < a; j++)
                    for (int k = 0; k < b; k++)
                        chl[i][j][k] = Convert.ToChar(rand.Next(0x0061, 0x007A));
            }
        }

        static void ToPrint(ref List<char[][]> chl)
        {
            foreach (char[][] mas in chl)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = 0; j < mas[i].Length; j++)
                        Console.Write("{0, -4}", mas[i][j]);

                    Console.WriteLine();
                }
            }
        }
    }
}
