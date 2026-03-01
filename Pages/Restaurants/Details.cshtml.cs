using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NibbleApp.Data;
using NibbleApp.Models;

namespace NibbleApp.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly NibbleApp.Data.ApplicationDbContext _context;

        public DetailsModel(NibbleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .Include(r => r.Reviews)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.RestaurantId == id);

            if (restaurant is not null)
            {
                Restaurant = restaurant;

                return Page();
            }

            return NotFound();
        }
    }
}
