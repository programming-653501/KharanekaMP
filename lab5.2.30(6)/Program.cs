using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._2._30
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree a = new Tree();
            String[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < str.Length; i++)
            {
                a.Insert(str[i]);
            }

            Console.WriteLine();

            Console.WriteLine(a.Display(Side.left));
            Console.WriteLine(a.Display(Side.right));
             
            Console.Read();
        }
    }
}
