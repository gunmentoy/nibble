using Microsoft.EntityFrameworkCore;
using NibbleApp.Data;

namespace NibbleApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Data.ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Data.ApplicationDbContext>>()))
        {
            if (context == null || context.Restaurant == null)
            {
                throw new ArgumentNullException("Null NibbleAppContext");
            }

            // Look for any restaurants.
            if (context.Restaurant.Any())
            {
                return;   // DB has been seeded
            }

            context.Restaurant.AddRange(
                new Restaurant
                {
                    Name = "The French Table",
                    Cuisine = "French",
                    MoodTag = "Romantic",
                    PriceRange = "$$$",
                    Rating = 4.8,
                    Address = "1523 W Broadway, Vancouver",
                    IsSponsored = true
                },
                new Restaurant
                {
                    Name = "Nook Restaurant",
                    Cuisine = "Italian",
                    MoodTag = "Cozy",
                    PriceRange = "$$",
                    Rating = 4.5,
                    Address = "195 W 2nd Ave, Vancouver",
                    IsSponsored = false
                },
                new Restaurant
                {
                    Name = "Miku Vancouver",
                    Cuisine = "Sushi",
                    MoodTag = "Scenic",
                    PriceRange = "$$$",
                    Rating = 4.7,
                    Address = "200 Granville St, Vancouver",
                    IsSponsored = true
                },
                new Restaurant
                {
                    Name = "Taco Nada",
                    Cuisine = "Mexican",
                    MoodTag = "Quick Bite",
                    PriceRange = "$",
                    Rating = 4.2,
                    Address = "4380 Main St, Vancouver",
                    IsSponsored = false
                },
                new Restaurant
                {
                    Name = "AnnaLena",
                    Cuisine = "Canadian",
                    MoodTag = "Adventurous",
                    PriceRange = "$$$",
                    Rating = 4.6,
                    Address = "1809 W 1st Ave, Vancouver",
                    IsSponsored = false
                },
                new Restaurant
                {
                    Name = "The Keg Steakhouse",
                    Cuisine = "Steakhouse",
                    MoodTag = "Celebrate",
                    PriceRange = "$$$",
                    Rating = 4.3,
                    Address = "1499 Anderson St, Vancouver",
                    IsSponsored = true
                }
            );
            context.SaveChanges();

            // Seed reviews (related data)
            context.Review.AddRange(
                new Review
                {
                    RestaurantId = 1,
                    ReviewerName = "Alice",
                    ReviewDate = DateTime.Parse("2025-12-01"),
                    Score = 5,
                    Comment = "Amazing French cuisine, very romantic atmosphere!"
                },
                new Review
                {
                    RestaurantId = 1,
                    ReviewerName = "Bob",
                    ReviewDate = DateTime.Parse("2025-12-15"),
                    Score = 4,
                    Comment = "Great food but a bit pricey."
                },
                new Review
                {
                    RestaurantId = 2,
                    ReviewerName = "Carol",
                    ReviewDate = DateTime.Parse("2026-01-05"),
                    Score = 5,
                    Comment = "Cozy and delicious Italian dishes!"
                },
                new Review
                {
                    RestaurantId = 3,
                    ReviewerName = "Dave",
                    ReviewDate = DateTime.Parse("2026-01-10"),
                    Score = 5,
                    Comment = "Best sushi in Vancouver, beautiful views."
                },
                new Review
                {
                    RestaurantId = 3,
                    ReviewerName = "Eve",
                    ReviewDate = DateTime.Parse("2026-01-20"),
                    Score = 4,
                    Comment = "Lovely spot, but long wait times."
                },
                new Review
                {
                    RestaurantId = 4,
                    ReviewerName = "Frank",
                    ReviewDate = DateTime.Parse("2026-02-01"),
                    Score = 4,
                    Comment = "Quick, affordable, and tasty tacos."
                },
                new Review
                {
                    RestaurantId = 5,
                    ReviewerName = "Grace",
                    ReviewDate = DateTime.Parse("2026-02-10"),
                    Score = 5,
                    Comment = "Creative menu, worth the splurge!"
                },
                new Review
                {
                    RestaurantId = 6,
                    ReviewerName = "Hank",
                    ReviewDate = DateTime.Parse("2026-02-14"),
                    Score = 4,
                    Comment = "Perfect for celebrations, great steaks."
                }
            );
            context.SaveChanges();
        }
    }
}
