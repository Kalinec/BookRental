using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Model.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Book(int id, string title, string author, string iSBN)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
        }

        public Book(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
        }
    }
}
