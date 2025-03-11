using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;        // handles user authentication!
using KelleSolutions.Models;
using KelleSolutions.Data;
using System;
using System.Threading.Tasks;

namespace KelleSolutions.Pages.Properties {
    public class CreatePropertyModel : PageModel {
        
        // database context for querying property
        private readonly KelleSolutionsDbContext _context;

        // manages logged-in users
        private readonly UserManager<User> _userManager;
        public CreatePropertyModel(KelleSolutionsDbContext context, UserManager<User> userManager) {
            _context = context;
            _userManager = userManager;
            // initialize empty Property
            Property = new Property {
                OwnerID = "",
                Address = string.Empty,
                City = string.Empty,
                State = string.Empty,
                ZipCode = string.Empty,
                BedCount = 0,
                BathCount = 0,
                GarageCount = 0,
                // default to current year
                YearConstructed = DateTime.UtcNow.Year,
                // default to first option
                PropertyType = string.Empty,
                // ensure it's set before assigning the real user ID
                UserID = string.Empty
            };
        }

        // Bind the Property model to the form
        [BindProperty]
        public Property Property { get; set; }

        public IActionResult OnGet() {
            // Loads the page (no specific logic needed for Get request here)
            return Page();
        }
        public async Task<IActionResult> OnPostAsync() {
            // Validates the form input
            if (!ModelState.IsValid) {
                return Page();
            }
            try {
                // get the currently logged-in user, specifically the user's username
                var currentUser = await _userManager.GetUserAsync(User);

                // if no user is logged in, redirect to the login page
                // while in testing phase, keep this commented!
                if (currentUser == null) {
                    return RedirectToPage("/Account/Login");
                }
                
                // new property entry in Property table
                var newProperty = new Property {
                    UserID = currentUser.Id,
                    Address = Property.Address,
                    City = Property.City,
                    State = Property.State,
                    ZipCode = Property.ZipCode,
                    BedCount = Property.BedCount,
                    BathCount = Property.BathCount,
                    GarageCount = Property.GarageCount,
                    YearConstructed = Property.YearConstructed, 
                    PropertyType = Property.PropertyType,
                    CreatedAt = DateTime.UtcNow,
                    OwnerID = currentUser.Id
                };

                // Save the new property to the database
                _context.Properties.Add(newProperty);
                await _context.SaveChangesAsync();
                // Redirect to the My Properties page after saving
                return RedirectToPage("/Properties/MyProperties");
            }
            catch (Exception ex) {
                ModelState.AddModelError("", "An error occurred while saving the property. Please try again.");
                Console.WriteLine($"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
