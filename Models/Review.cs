using System.ComponentModel.DataAnnotations;

namespace NibbleApp.Models;

public class Review
{
    public int ReviewId { get; set; }

    public int RestaurantId { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string ReviewerName { get; set; } = string.Empty;

    [Display(Name = "Review Date")]
    [DataType(DataType.Date)]
    public DateTime ReviewDate { get; set; }

    [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
    public int Score { get; set; }

    [StringLength(500)]
    public string Comment { get; set; } = string.Empty;

    public Restaurant Restaurant { get; set; }
}
