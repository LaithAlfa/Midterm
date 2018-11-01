using System;
using System.Linq;
using System.Collections.Generic;

namespace MidtermLinq
{
    public class Book
    {
        //PK
        public int BookID { get; set; } 

        public string BookTitle {get; set;}
        public string Publisher { get; set; } 
        public DateTime PDate{get; set; }

        public int Pages{get; set;}




        //FK
        public int AuthorID {get; set;}

        public int AuthorFirstName {get; set;}

        public int AuthorLastName {get; set;}

        public override string ToString()
        {
            return $"{ BookID} - {Publisher} - {BookTitle} -{AuthorID}-{PDate}-{Pages}";
        }

    }
}