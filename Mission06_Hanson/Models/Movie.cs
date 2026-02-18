using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Hanson.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please choose Yes or No.")]
        public bool? CopiedToPlex { get; set; }

        [Required(ErrorMessage = "Please choose Yes or No.")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
