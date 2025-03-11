using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;            // handles user authentication!
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;               // defines database relationships
using System.Linq;                              // defines LINQ queries (ex: "Where", "OrderBy", "Skip", "Take", etc.)
using System;                                   
using System.Reflection;                        // required for extracting Display Names
using System.ComponentModel.DataAnnotations;    // required for Display attribute
using System.Threading.Tasks;                   // supports non-blocking queries (ex: "async", "await")
using KelleSolutions.Data;                      // imports KelleSolutionsDbContext.cs
using KelleSolutions.Models;                    // imports model classes
using KelleSolutions.Models.ViewModels;         // imports ViewModel for displaying user properties

namespace KelleSolutions.Pages.Properties {
    public class MyPropertiesModel : PageModel {
        
        // Database context for querying properties
        private readonly KelleSolutionsDbContext _context;
        
        // Manages logged-in users
        private readonly UserManager<User> _userManager;

        // Constructor injecting database context and user manager
        public MyPropertiesModel(KelleSolutionsDbContext context, UserManager<User> userManager) {
            _context = context;
            _userManager = userManager;
        }

        // Stores the properties available to the user
        public List<ViewUserProperties> AllProperties { get; set; } = new();
        public List<ViewUserProperties> ViewUserProperties { get; set; } = new();

        public List<Property> MyProperties { get; set; } = new();

        // Available property types list
        public List<KeyValuePair<string, string>> AvailablePropertyTypesList { get; set; } = new();

        // Page display properties
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        // Total number of pages based on available properties
        public int TotalPages => (int)Math.Ceiling((double)AllProperties.Count / PageSize);

        public async Task<IActionResult> OnGetAsync() {
            // Gets the currently logged-in user
            var currentUser = await _userManager.GetUserAsync(User);

            // If no user is logged in, redirect to login page
            if (currentUser == null) {
                return RedirectToPage("/Account/Login");
            }

            MyProperties = await _context.Properties.ToListAsync();

            // Fetch roles for the logged-in user
            var roles = await _userManager.GetRolesAsync(currentUser);

            // Query to fetch properties
            var query = _context.Properties.AsQueryable();

            // If user is a broker or agent, filter based on ownership
            if (roles.Contains("Broker") || roles.Contains("Agent")) {
                query = query.Where(p => p.UserID == currentUser.Id);
            }

            // Fetch property data from database
            var propertiesFromDb = await query
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new {
                    p.PropertyID,
                    p.CreatedAt,
                    p.State,
                    p.City,
                    p.ZipCode,
                    p.Address,
                    p.BedCount,
                    p.BathCount
                })
                .ToListAsync();

            // Convert database properties to ViewModel structure
            AllProperties = propertiesFromDb.Select(p => new ViewUserProperties {
                ID = p.PropertyID,
                CreationDate = DateOnly.FromDateTime(p.CreatedAt),
                County = p.State,
                City = p.City,
                Postal = int.TryParse(p.ZipCode, out int zip) ? zip : 0,
                Street = p.Address,
                Bed = p.BedCount,
                Bath = p.BathCount
            })
            .ToList();

            // Paginate properties
            ViewUserProperties = AllProperties
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // Fetch available property types dynamically
            AvailablePropertyTypesList = Enum.GetValues(typeof(Property.PropertyTypes))
                .Cast<Property.PropertyTypes>()
                .Select(pt => new KeyValuePair<string, string>(
                    pt.ToString(),
                    pt.GetType().GetMember(pt.ToString())?
                        .FirstOrDefault()?
                        .GetCustomAttribute<DisplayAttribute>()?.Name ?? pt.ToString()
                ))
                .ToList();

            return Page();
        }
    }
}
