using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KelleSolutions.Data; // imports DbContext
using KelleSolutions.Models; // imports Person model

namespace KelleSolutions.Pages.People {
    public class AllPeopleModel : PageModel {
        // database context for querying people
        private readonly KelleSolutionsDbContext _context;

        // constructor that injects database context
        public AllPeopleModel(KelleSolutionsDbContext context)
        {
            _context = context;
        }

        // list of all people to be displayed
        public List<Person> AllPeople { get; set; } = new();
        // storing list of categories (ex: "Admin", "Broker", "Agent")
        public List<Category> Categories { get; set; } = new();

        // Pagination properties
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10; // Default: 10 per page

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1; // Current page number

        public int TotalPages { get; set; } // Total pages count

        public async Task<IActionResult> OnGetAsync()
        {
            // query all people from the database
            var query = _context.People.AsQueryable();

            // get the total count for pagination
            int totalPeople = await query.CountAsync();
            TotalPages = (int)System.Math.Ceiling((double)totalPeople / PageSize);

            // apply pagination: skip previous pages, take only PageSize records
            AllPeople = await query
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            
            // get categories
            var categories = await _context.Categories.ToListAsync();

            return Page();
        }
    }
}
