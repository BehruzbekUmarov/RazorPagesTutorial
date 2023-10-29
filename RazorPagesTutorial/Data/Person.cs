using System.ComponentModel.DataAnnotations;

namespace RazorPagesTutorial.Data
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
