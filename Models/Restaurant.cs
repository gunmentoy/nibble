using System.ComponentModel.DataAnnotations;

namespace NibbleApp.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Cuisine must start with a capital letter and contain only letters.")]
    [StringLength(50)]
    public string Cuisine { get; set; } = string.Empty;

    [Display(Name = "Mood Tag")]
    [Required]
    [StringLength(30)]
    public string MoodTag { get; set; } = string.Empty;

    [Display(Name = "Price Range")]
    [Required]
    [RegularExpression(@"^\${1,4}$", ErrorMessage = "Price Range must be $ to $$$$.")]
    [StringLength(10)]
    public string PriceRange { get; set; } = string.Empty;

    [Range(0.0, 5.0, ErrorMessage = "Rating must be between 0 and 5.")]
    public double Rating { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 5)]
    public string Address { get; set; } = string.Empty;

    [Display(Name = "Sponsored")]
    public bool IsSponsored { get; set; }

    public ICollection<Review> Reviews { get; set; }
}
