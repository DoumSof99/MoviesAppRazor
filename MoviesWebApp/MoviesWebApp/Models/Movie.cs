using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models;

public class Movie
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    public string Title { get; set; } = null!;

    [Display(Name= "Release Date"), DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [RegularExpression(@"^[A-Z][a-z]*$"), Required, StringLength(30)]
    public string? Genre { get; set; }

    [Range(1, 100), DataType(DataType.Currency)]
    [Column(TypeName ="decimal(18, 2)")]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]{2}$"), StringLength(2)]
    public string Rating { get; set; } = string.Empty;
}

