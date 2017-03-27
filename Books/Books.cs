using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public struct OneBook
    {
        public string name;
        public string author;
        public uint number;
        public decimal sellPrice;
        public decimal buyPrice;
        public string requisites;
    }

    internal class Pics
    {
        public string Requisites { get; internal set; }
        public decimal BuyPrice { get; internal set; }
        public decimal SellPrice { get; internal set; }
        public uint Number { get; internal set; }
    }

    public partial class Book : IComparable<Book>
    {
        public static uint OverallNumber { get; internal set; }
        public static decimal OverallCost { get; internal set; }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public uint Number { get; private set; }
        internal List<Pics> pics = new List<Pics>();

        internal Book next;
        internal Book prev;

        public int CompareTo(Book b)
        {
            return Author.CompareTo(b.Author);
        }

        public static void Add(ref Book b, OneBook newBook)
        {
            OverallNumber += newBook.number;
            OverallCost += newBook.sellPrice * newBook.number;


            if (b.Name == null || (b.Name == newBook.name && b.Author == newBook.author))
            {
                b += newBook;
            }
            else if (b.next != null)
                Add(ref b.next, newBook);

            else if (b.next == null)
            {
                b.next += newBook;
                b.next.prev = b;
            }

            

        }

       
        

    }
}