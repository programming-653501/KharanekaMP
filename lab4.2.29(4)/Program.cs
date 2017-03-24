using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4._2._29
{
    class Pair : IComparable <Pair>
    {
        public string str;
        public int num;

        public int CompareTo(Pair p)
        {
            if (p.num > num)
                return -1;
            else if (p.num < num)
                return 1;
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Pair> sList = new List<Pair>();
            

            using (StreamReader reader = new StreamReader(@"file.txt"))
            {
                char[] ch = new char[4];
                int i = 0;
                
                while (!reader.EndOfStream)
                {
                    sList.Add(new Pair { str = reader.ReadLine() });
                    sList[i].str.CopyTo(sList[i].str.Length - 4, ch, 0, 4);
                    sList[i].num = Convert.ToInt32(new string(ch));
                    i++;
                }
            }
            
            sList.Sort();

            using (StreamWriter writer = new StreamWriter(@"file.txt", false))
            {
                foreach (Pair s in sList)
                    writer.WriteLine(s.str);
            }
            
            

        }
    }
}
