using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._1._30
{

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> a = new Stack<int>();
            Stack<int> b = new Stack<int>();
            bool isAlive = true;

            a.Push(5);
            a.Push(52);
            a.Push(35);
            a.Push(23);
            a.Push(324);
            a.Push(512);
            a.Push(54);
            a.Push(523);

            a.CopyStack(b);//Вызов созданного метода расширения.
            
            while (isAlive)
            {
                try
                {
                    Console.WriteLine($"b - {b.Pop()}");
                    Console.WriteLine($"a - {a.Pop()}");
                }
                catch (InvalidOperationException)
                {
                    isAlive = false;
                }
            }

            Console.Read();
        }


    }

    public static class Ext
    {
        public static void CopyStack<T>(this Stack<T> a, Stack<T> b)
        {
            Stack<T> c = new Stack<T>(); // Создаем промежуточный экземпляр стека.

            bool isAlive = true; // Флаг, оповещающий об окончании стека.

            while (isAlive)
                try
                {
                    c.Push(a.Pop()); // Копируем каждый из элементов в промежуточный стек. Там они расположатся в обратном порядке.
                }
                catch (InvalidOperationException)
                {
                    isAlive = false; // Установка флага, означающего окончание стека.
                }

            isAlive = true;

            while (isAlive)
                try
                {
                    b.Push(c.Peek()); // Копируем значения из промежуточного стека в копируемый и целевой стек.
                    a.Push(c.Pop());
                }
                catch (InvalidOperationException)
                {
                    isAlive = false;
                }
        }
    }



}
