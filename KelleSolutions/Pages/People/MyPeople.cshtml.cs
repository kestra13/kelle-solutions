using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;    // handles user authentication!
using System.Collections.Generic;       // defines database relationships
using System.Linq;                      // defines LINQ queries (ex: "Where", "OrderBy", "Skip", "Take", etc.)
using System.Threading.Tasks;           // supports non-blocking queries (ex: "async", "await")
using KelleSolutions.Data;              // imports KelleSolutionsDbContext.cs
using KelleSolutions.Models;            // imports model classes, like "Person.cs" as Person and "User.cs" as User

namespace KelleSolutions.Pages.People {
    public class MyPeopleModel : PageModel {
        // database context for querying people
        private readonly KelleSolutionsDbContext _context;
        private readonly UserManager<User> _userManager;

        // constructor that injects database context & user manager
        public MyPeopleModel(KelleSolutionsDbContext context, UserManager<User> userManager) {
            _context = context;
            _userManager = userManager;
        }

        // storing the list of affiliated people
        public List<Person> MyPeople { get; set; } = new();

        // storing the list of teams (ex: "Scrumbags", "KelleSolutions")
        public List<Team> Teams { get; set; } = new();

        // storing list of categories (ex: "Admin", "Broker", "Agent")
        public List<Category> Categories { get; set; } = new();

        // storing the CreatePersonModalModel
        public CreatePersonModalModel CreatePersonModal { get; set; }

        // page display properties
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;  // default to 10 per page

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;  // current page number

        public int TotalPages { get; set; }  // total number of pages

        public async Task<IActionResult> OnGetAsync() {
            // get the currently logged-in user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) {
                return Unauthorized();  // ensure user is logged in
            }

            // retrieve only people from the logged-in user's affiliation (Team)
            var teamId = await _context.Teams
                .Where(t => t.Affiliation == currentUser.Affiliation)
                .Select(t => t.TeamId)
                .FirstOrDefaultAsync();

            // handle case where team is not found 
            if (teamId == 0) {
                return BadRequest("Your affiliation does not have a corresponding Team ID.");
            }

            // retrieve only people from the logged-in user's affiliation (Team)
            var query = _context.People
                .Where(p => p.Team == teamId)
                .AsQueryable();

            // get total count for pagination
            int totalPeople = await query.CountAsync();
            TotalPages = (int)System.Math.Ceiling((double)totalPeople / PageSize);

            // apply pagination: skip previous pages, take only PageSize records
            MyPeople = await query
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            
            Console.WriteLine($"People loaded: {MyPeople.Count}");
            
            // get teams
            var teams = await _context.Teams.ToListAsync();

            // get categories
            var categories = await _context.Categories.ToListAsync();

            Console.WriteLine($"Teams Count: {teams.Count}");
            Console.WriteLine($"Categories Count: {categories.Count}");

            // initialize CreatePersonModalModel
            CreatePersonModal = new CreatePersonModalModel(_context, _userManager) {
                Teams = teams,
                Categories = categories
            };

            if (CreatePersonModal == null) {
                Console.WriteLine("Error: CreatePersonModal is STILL NULL after initialization!");
            }
            else {
                Console.WriteLine("CreatePersonModal successfully initialized!");
            }

            return Page();
        }
    }
}
