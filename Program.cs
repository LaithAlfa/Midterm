using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MidtermLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            SeedDatabase();

            /*
            BasicFiltersWithWhereQuerySyntax();            
            BasicFiltersWithWhereMethodSyntax();
            GroupByQuerySyntax();
            GroupByMethodSyntax();
            OrderByMethodSyntax();            
            OrderByQuerySyntax();               
            JoinMethodSyntax();            
            JoinQuerySyntax();            
            GroupJoinMethodSyntax();            
            */

           

        }

        public static void BasicShowAllBooks()
        {
            using(var db = new AppDbContext())
            {
               var Book = db.Book.ToList();

                    Console.WriteLine("ALL RECORDS IN Book THE TABLE");
                    foreach(Book s in Book)
                        {
                            Console.WriteLine(s);
                        }
                    Console.WriteLine(Book);
            }
        }
           public static void BasicShowPublisherByApress()
        {
            using(var db = new AppDbContext())
            {
               var PublishedbyAPress = db.Book.Where(s => s.Publisher == "APress");

                    Console.WriteLine("Books That were Published by APress");
                    foreach(Book s in PublishedbyAPress)
                        {
                            Console.WriteLine(s);
                        }
                    Console.WriteLine("");
            }
        } 

        public static void GroupFirstNameShortest()
        {
            using(var db = new AppDbContext())
            {           
               Console.WriteLine("Books whose author's first name is the shortest ");

              var shortName = db.Book.Min(s => s.AuthorFirstName);
              var acuFName = db.Book.Where(s => s.AuthorFirstName == shortName);
            
            foreach (var book in acuFName)
            {
                Console.WriteLine(book);
                Console.WriteLine();

            }              
        }
     }

        public static void BasicAuthorNamedAdam()
        {
            using(var db = new AppDbContext())
            {
                     Console.WriteLine("FIRST NAME BEGINS WITH 'Adam'");

                    var FirstNameAdam = db.Book.Include(s => s.AuthorID);
                    var authAdam = FirstNameAdam.FirstOrDefault(s => s.AuthorFirstName == 1);

                   
                   Console.WriteLine(FirstNameAdam);
            }       
                 
                
                       

        }

        public static void OrderByPageMorethen100()
        {
            using(var db = new AppDbContext())
            {
                var CountGreater  = db.Book.Where(s => s.Pages > 1000);

                Console.WriteLine(CountGreater);
            }   
        }



        public static void OrderByLastName()
        {
            using(var db = new AppDbContext())
            {
                 Console.WriteLine("Books whose author's first name is the shortest ");

                var BookAuthorLastName = from s in db.Book
                                       orderby s.AuthorLastName
                                       select s;
                    foreach(Book s in BookAuthorLastName){
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("");                                   
            }               
        }

     public static void DesecndingBookTitle ()
        {
            using(var db = new AppDbContext())
            {
             var DesecndingBookTitle = from s in db.Book
                                        orderby s.BookTitle descending
                                        select s;
                Console.WriteLine(DesecndingBookTitle);
            }             
        }

    public static void BooksGroupedByPublisher()
        {
            using (var db = new AppDbContext())
            {
                var BooksGroupedByPublisher = db.Book.Include(s => s.AuthorID);
                var PubBook = BooksGroupedByPublisher.GroupBy(s => s.Publisher);

              

                foreach (var Book in PubBook)
                {
                    {
                        Console.WriteLine(BooksGroupedByPublisher);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }

            }
        }

          public static void AuthorNamePublisher()
        {
            using (var db = new AppDbContext())
            {
                var books = db.Book.Include(s =>  s.AuthorID);
                var AuthorNamePublisher  = books.OrderBy(s => s.AuthorLastName).GroupBy(p => p.Publisher);
             

            
              foreach (var book in AuthorNamePublisher)
                {
                 foreach (var b in AuthorNamePublisher)
                    {
                        Console.WriteLine(b);
                        Console.WriteLine();
                    }
                }
        }  }
        
        



        public static void SeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                try
                {

                    //first, if it is there, delete it
                    //db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if(!db.Author.Any() && !db.Book.Any())
                    {
                        IList<Book> Book = new List<Book>()
                        {
                            new Book() { BookID = 1, BookTitle="Pro ASP.NET Core MVC 2 ", Publisher = " Apress", PDate = DateTime.Parse("October 25, 2017"), Pages= 1017, AuthorID = 1},
                            new Book() { BookID = 2, BookTitle=" Pro Angular 6 3rd Edition", Publisher = "Apress", PDate= DateTime.Parse("October 10, 2018"), Pages = 776, AuthorID = 1},
                            new Book() { BookID = 3, BookTitle="Programming Microsoft Azure Service Fabric (Developer Reference) 2nd EditionPublisher", Publisher = "Microsoft Press", PDate= DateTime.Parse("May 25, 2018"), Pages= 528, AuthorID = 1}
                        };

                        db.Book.AddRange(Book);

                        IList<Author> studentList = new List<Author>() { 
                            new Author() { AuthorID = 1, AuthorFirstName = "Adam",  AuthorLastName = "Freeman",},
                            new Author() { AuthorID = 2, AuthorFirstName = "Adam", AuthorLastName = "Freeman",},
                            new Author() { AuthorID = 3, AuthorFirstName = "Haishi",  AuthorLastName = "Bai",}
                           
                        };  

                        db.Author.AddRange(studentList);

                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("We have existing records in the db");
                    }
                }
                catch(Exception exp)
                {
                    Console.Error.WriteLine(exp.Message);
                }
            }
        }

      
    }
 }

