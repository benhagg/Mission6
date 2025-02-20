using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Mission6.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set;}

        // set the FK to the Categories table (by convention)
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
