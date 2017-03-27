using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public partial class Book
    {
        public static Book operator +(Book left, OneBook right)
        {
            if (left == null || left.Author == null)
            {
                left = new Book();
                left.Author = right.author;
                left.Name = right.name;
            }

            left.Number += right.number;
            left.pics.Add(new Pics { Requisites = right.requisites, Number = right.number, BuyPrice = right.buyPrice, SellPrice = right.sellPrice});
            return left;
        }

        public static (Book, decimal, decimal) operator -(Book book, uint num)
        {
            decimal sum = 0;
            decimal clearsum = 0;
            book.Number -= num;
            foreach (Pics p in book.pics)
            {
                if (num > p.Number)
                {
                    num -= p.Number;
                    sum += p.Number * p.SellPrice;
                    clearsum += p.Number * (p.SellPrice - p.BuyPrice);
                }
                else
                {
                    p.Number -= num;
                    sum += num * p.SellPrice;
                    clearsum += num * (p.SellPrice - p.BuyPrice);
                }
            }
            return (book, sum, clearsum);
        }
    }
}
