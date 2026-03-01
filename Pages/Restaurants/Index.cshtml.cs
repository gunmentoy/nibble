using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NibbleApp.Data;
using NibbleApp.Models;

namespace NibbleApp.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly NibbleApp.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(NibbleApp.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string RatingSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentMood { get; set; }

        public SelectList MoodTags { get; set; }

        public PaginatedList<Restaurant> Restaurant { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString,
            string restaurantMood, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            RatingSort = sortOrder == "Rating" ? "rating_desc" : "Rating";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            CurrentMood = restaurantMood;

            IQueryable<string> moodQuery = from r in _context.Restaurant
                                           orderby r.MoodTag
                                           select r.MoodTag;

            IQueryable<Restaurant> restaurantsIQ = from r in _context.Restaurant
                                                   select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                restaurantsIQ = restaurantsIQ.Where(r => r.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(restaurantMood))
            {
                restaurantsIQ = restaurantsIQ.Where(r => r.MoodTag == restaurantMood);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    restaurantsIQ = restaurantsIQ.OrderByDescending(r => r.Name);
                    break;
                case "Rating":
                    restaurantsIQ = restaurantsIQ.OrderBy(r => r.Rating);
                    break;
                case "rating_desc":
                    restaurantsIQ = restaurantsIQ.OrderByDescending(r => r.Rating);
                    break;
                default:
                    restaurantsIQ = restaurantsIQ.OrderBy(r => r.Name);
                    break;
            }

            MoodTags = new SelectList(await moodQuery.Distinct().ToListAsync());

            var pageSize = Configuration.GetValue("PageSize", 4);
            Restaurant = await PaginatedList<Restaurant>.CreateAsync(
                restaurantsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
