using Microsoft.EntityFrameworkCore;
using Optional;
using System.Collections.Generic;
using System.Linq;

namespace HealthForge.AspNetDemo.Models
{
    public class BookRepository : IBookRepository
    {
        BookContext DB;

        public BookRepository(BookContext db) {
            DB = db;
        }

        public IEnumerable<Book> GetAll()
        {
            return DB.Books.ToList();
        }

        public Option<Book> Get(string isbn)
        {
            return DB.Books.Find(isbn).SomeNotNull();
        }

        public void Add(Book book)
        {
            DB.Books.Add(book);
            DB.SaveChanges();
        }

        public void Update(Book newBook)
        {
            Get(newBook.ISBN).MatchSome(oldBook =>
            {
                DB.Entry(oldBook).State = EntityState.Detached;
                DB.Books.Update(newBook);
                DB.SaveChanges();
            });
        }

        public void Delete(string isbn)
        {
            Get(isbn).MatchSome(book =>
            {
                DB.Books.Remove(book);
                DB.SaveChanges();
            });
        }
    }
}
