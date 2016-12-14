using Optional;
using System.Collections.Generic;

namespace HealthForge.AspNetDemo.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Option<Book> Get(string isbn);
        void Add(Book book);
        void Update(Book book);
        void Delete(string isbn);
    }
}
