using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._1_2._1._28_
{
    class Program
    {
        const string ksis = "fksis.txt", tk = "ftk.txt", re = "fre.txt", ity = "fity.txt", kp = "fkp.txt";
        static int[] a = {331, 300, 272, 184, 138 };

        static void WriteInfo(string filename)
        { 
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filename, Encoding.GetEncoding(1251));

            while ((line = file.ReadLine()) != null)
                System.Console.WriteLine(line);
        }

        static int GetNum()
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Хорошая попытка.");
                return GetNum();
            }
            return n;
        }

        static void Recommend()
        {
            int math, phys, russ, ates, sum, numOfFac = 0;
            Console.Write("Введите свои баллы:\nПо математике: ");
            math = GetNum();
            Console.Write("По физике: ");
            phys = GetNum();
            Console.Write("По русскому языку: ");
            russ = GetNum();
            Console.Write("Атестат: ");
            ates = GetNum();
            sum = math + phys + russ + ates;
            if (math+phys < russ)
                Console.WriteLine("Идите лучше в МГЛУ");
            else if (sum < a[4])
                Console.WriteLine("Не теряйте время даром");
            else
            {
                Console.WriteLine("Лучший выбор для Вас:");
                while (sum < a[numOfFac])
                    numOfFac++;
                switch (numOfFac)
                {
                    case 0:
                        WriteInfo(ksis);
                        break;
                    case 1:
                        WriteInfo(ity);
                        break;
                    case 2:
                        WriteInfo(kp);
                        break;
                    case 3:
                        WriteInfo(tk);
                        break;
                    case 4:
                        WriteInfo(re);
                        break;
                }
            }
            
        }


        static void Main(string[] args)
        {
            bool go = true;
            Console.WriteLine("Выберите функцию:\n1. О факультете КСиС.\n2. О факультете ИТиУ.\n3. О факультете РЭ.\n4. О факультете ТК.\n5. О факультете КП.\n6. Рекомендации.\n7. Выход.");
            while (go)
            {
                int n = 0;
                switch (n = GetNum())
                {
                    case 1:
                        WriteInfo(ksis);
                        break;
                    case 2:
                        WriteInfo(ity);
                        break;
                    case 3:
                        WriteInfo(re);
                        break;
                    case 4:
                        WriteInfo(tk);
                        break;
                    case 5:
                        WriteInfo(kp);
                        break;
                    case 6:
                        Recommend();
                        break;
                    case 7:
                        go = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
