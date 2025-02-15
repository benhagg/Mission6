using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace Mission6.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set;}
        public string Title { get; set; }

        public int Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
