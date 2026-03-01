using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NibbleApp.Models;

namespace NibbleApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{

public DbSet<NibbleApp.Models.Restaurant> Restaurant { get; set; } = default!;
public DbSet<NibbleApp.Models.Review> Review { get; set; } = default!;
}
