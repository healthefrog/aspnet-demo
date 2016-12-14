using HealthForge.AspNetDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HealthForge.AspNetDemo.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        IBookRepository Books;

        public BooksController(IBookRepository books)
        {
            Books = books;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return Books.GetAll();
        }

        [HttpGet("{isbn}", Name = "GetBook")]
        public IActionResult Get(string isbn)
        {
            return Books.Get(isbn).Match<IActionResult>(book => new ObjectResult(book), () => NotFound());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            Books.Add(book);
            return CreatedAtRoute("GetBook", new { isbn = book.ISBN }, book);
        }

        [HttpPut("{isbn}")]
        public IActionResult Update(string isbn, [FromBody] Book book)
        {
            if (book == null || book.ISBN != isbn) return BadRequest();
            if (!Books.Get(isbn).HasValue) return NotFound();

            Books.Update(book);
            return new NoContentResult();
        }

        [HttpDelete("{isbn}")]
        public IActionResult Delete(string isbn)
        {
            if (!Books.Get(isbn).HasValue) return NotFound();

            Books.Delete(isbn);
            return new NoContentResult();
        }
    }
}
