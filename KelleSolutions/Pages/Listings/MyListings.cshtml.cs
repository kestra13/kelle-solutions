using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;               // Defines database relationships
using System.Linq;                              // Defines LINQ queries (ex: "Where", "OrderBy", "Skip", "Take", etc.)
using System.Reflection;                        // Required for extracting Display Names
using System.ComponentModel.DataAnnotations;    // Required for Display attribute
using System.Threading.Tasks;                   // Supports non-blocking queries (ex: "async", "await")
using KelleSolutions.Data;                      // Imports KelleSolutionsDbContext.cs
using KelleSolutions.Models;                    // Imports model classes
using KelleSolutions.Models.ViewModels;         // Imports ViewModel for displaying user listings

namespace KelleSolutions.Pages.Listings {
    public class MyListingsModel : PageModel {
        
        // Database context for querying listings
        private readonly KelleSolutionsDbContext _context;
        
        // Manages logged-in users
        private readonly UserManager<User> _userManager;

        // Constructor injecting database context and user manager
        public MyListingsModel(KelleSolutionsDbContext context, UserManager<User> userManager) {
            _context = context;
            _userManager = userManager;
        }

        // Stores listings available to the user
        public List<ViewUserListings> AllListings { get; set; } = new();
        public List<ViewUserListings> MyListings { get; set; } = new();
        public CreateListingModalModel CreateListingModel { get; set; }
        public List<KeyValuePair<string, string>> AvailableStatusTypesList { get; set; } = new();

        // Page display properties
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        // Total number of pages based on available listings
        public int TotalPages => (int)Math.Ceiling((double)AllListings.Count / PageSize);

        public async Task<IActionResult> OnGetAsync() {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null) {
                return RedirectToPage("/Account/Login");
            }

            var roles = await _userManager.GetRolesAsync(currentUser);

            var listingsQuery = _context.Listings
                .Include(l => l.Property)
                .Include(l => l.Agent)
                .AsQueryable();

            if (roles.Contains("Broker") || roles.Contains("Agent")) {
                listingsQuery = listingsQuery.Where(l => l.AgentID == currentUser.Id);
            }

            // Fetch raw listing data FIRST (without Enum.GetName)
            var rawListings = await listingsQuery
                .OrderByDescending(l => l.StartDate)
                // Fetch from DB first!
                .ToListAsync();

            AllListings = rawListings.Select(l => new ViewUserListings {
                ListingID = l.ListingID,
                ListingDate = DateOnly.FromDateTime(l.StartDate),
                Status = l.Status.ToString(),
                Operator = l.Agent.FirstName + " " + l.Agent.LastName,
                Affiliation = l.Agent.Affiliation ?? "N/A",
                Price = (double)l.Price,
                Address = $"{l.Property.Address}, {l.Property.City}, {l.Property.State} {l.Property.ZipCode}"
            }).ToList();

            // Paginate
            MyListings = AllListings
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // Initialize CreateListingModel
            CreateListingModel = new CreateListingModalModel(_context, _userManager, User);
            await CreateListingModel.OnGetAsync();

            // Fetch available status types dynamically
            AvailableStatusTypesList = Enum.GetValues(typeof(Listing.StatusTypes))
                .Cast<Listing.StatusTypes>()
                .Select(status => new KeyValuePair<string, string>(
                    status.ToString(),
                    status.GetType().GetMember(status.ToString())?
                        .FirstOrDefault()?
                        .GetCustomAttribute<DisplayAttribute>()?.Name ?? status.ToString()
                ))
                .ToList();

            return Page();
        }


        public async Task<JsonResult> OnPostUpdateStatusAsync([FromBody] UpdateStatusModel request) {
            // Find the listing in the database by its ListingID
            var listing = await _context.Listings.FindAsync(request.Id);

            // Error response if listing is not found
            if (listing == null) {
                return new JsonResult(new { success = false, message = "Listing not found " });
            }

            // Parsing the incoming status string into the StatusTypes enum
            if (Enum.TryParse(typeof(Listing.StatusTypes), request.Status, out var status)) {
                // Update the listing status
                listing.Status = (Listing.StatusTypes)status;

                // Save changes
                await _context.SaveChangesAsync();

                // Return a success response
                return new JsonResult(new { success = true });
            }

            // If parsing fails, error handler
            return new JsonResult(new { success = false, message = "Invalid Status" });
        }
    }
}

// View model for user listings
public class ViewUserListings {
    public int ListingID { get; set; }
    public DateOnly ListingDate { get; set; }
    public string Status { get; set; }
    public string Operator { get; set; }
    public string Affiliation { get; set; }
    public double Price { get; set; }
    public string Address { get; set; }
}

// Data transfer class for AJAX status update request
public class UpdateStatusModel {
    public int Id { get; set; }
    public required string Status { get; set; }
}
