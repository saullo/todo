using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Todo
    {
        [Key] public int Id { get; set; }
        [Required] [MinLength(3)] public string Title { get; set; }
    }
}