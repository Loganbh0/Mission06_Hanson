using System.ComponentModel.DataAnnotations;

namespace Mission06_Hanson.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string Rating { get; set; } = string.Empty; // G, PG, PG-13, R

        public bool Edited { get; set; } // true/false (yes/no)

        public string? LentTo { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
