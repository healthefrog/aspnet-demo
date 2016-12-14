using System.ComponentModel.DataAnnotations;

namespace HealthForge.AspNetDemo.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}
