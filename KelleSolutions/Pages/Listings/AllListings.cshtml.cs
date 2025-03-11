using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;            // handles user authentication!
using System.Collections.Generic;               // defines database relationships
using System.Linq;                              // defines LINQ queries (ex: "Where", "OrderBy", "Skip", "Take", etc.)
using System.Threading.Tasks;                   // supports non-blocking queries (ex: "async", "wait")
using KelleSolutions.Data;                      // imports KelleSolutionsDbContext.cs
using KelleSolutions.Models;                    // imports model classes, like "Property.cs" as Property and "User.cs" as User

namespace KelleSolutions.Pages.Listings {
    public class AllListingsModel : PageModel {
        // database context for querying listings
        private readonly KelleSolutionsDbContext _context;

        // constructor that injects database context
        public AllListingsModel(KelleSolutionsDbContext context) {
            _context = context;
        }

        // storing the list of all listings
        public List<ViewUserListings> AllListings { get; set; } = new();

        // page display properties (not house properties, but like components properties),
        // clarification for later documentation
        // defaults to 10 listings per page
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        // the current page number
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        // the total number of pages
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync() {
            // retrieves all listings
            var query = _context.Listings
                // ensure Property details are loaded
                .Include(l => l.Property)
                // ensure User details are loaded through Property
                .ThenInclude(p => p.User)
                .Select(l => new ViewUserListings {
                    ListingID = l.ListingID,
                    Date = l.CreatedAt,
                    Status = l.Status.ToString(),
                    OperatorName = l.Property.User.FirstName + " " + l.Property.User.LastName,
                    Affiliation = l.Affiliation.ToString(),
                    Price = l.Price,
                    Address = l.Property.Address
                })
                .AsQueryable();

            // get the total listing count for page display properties (again)
            int totalListings = await query.CountAsync();
            TotalPages = (int)System.Math.Ceiling((double)totalListings / PageSize);

            // apply page display properties
            AllListings = await query
                // newest listings appear first
                .OrderByDescending(l => l.Date)
                // skips items from previous pages
                .Skip((PageNumber - 1) * PageSize)
                // limit the results to just PageSize
                .Take(PageSize)
                .ToListAsync();

            return Page();
        }

        // view model to format data properly
        public class ViewUserListings {
            public int ListingID { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
            public string OperatorName { get; set; }
            public string Affiliation { get; set; }
            public decimal Price { get; set; }
            public string Address { get; set; }
        }

    }
}