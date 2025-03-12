using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using KelleSolutions.Data;
using KelleSolutions.Models;

namespace KelleSolutions.Pages.People
{
    public class CreatePersonModalModel : PageModel
    {
        private readonly KelleSolutionsDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreatePersonModalModel(KelleSolutionsDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public Person NewPerson { get; set; } = new();

        public List<Team> Teams { get; set; } = new();
        public List<Category> Categories { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Categories = await _context.Categories.ToListAsync();
                Teams = await _context.Teams.ToListAsync();

                if (!Categories.Any() || !Teams.Any())
                {
                    return new JsonResult(new { success = false, error = "Teams or Categories are missing in the database." });
                }

                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return new JsonResult(new { success = false, error = "An error occurred while loading the form. Please try again." });
            }
        }

        public async Task<IActionResult> OnPostAsync() {
            Console.WriteLine("OnPostAsync() triggered...");

            if (!ModelState.IsValid) {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                Console.WriteLine("Validation failed: " + string.Join(", ", errors));
                return new JsonResult(new { success = false, errors });
            }

            if (string.IsNullOrWhiteSpace(NewPerson.Name_First) ||
                string.IsNullOrWhiteSpace(NewPerson.Name_Last) ||
                string.IsNullOrWhiteSpace(NewPerson.Email_Primary) ||
                string.IsNullOrWhiteSpace(NewPerson.Phone_Primary) ||
                NewPerson.Team == 0 ||
                NewPerson.CategoryId == 0)
            {
                return new JsonResult(new { success = false, errors = new List<string> { "All required fields must be filled." } });
            }

            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return new JsonResult(new { success = false, errors = new List<string> { "User is not authenticated." } });
                }

                if (string.IsNullOrEmpty(currentUser.Affiliation))
                {
                    return new JsonResult(new { success = false, errors = new List<string> { "Your user account does not have an affiliation set." } });
                }

                if (!_context.Teams.Any(t => t.TeamId == NewPerson.Team))
                {
                    return new JsonResult(new { success = false, errors = new List<string> { "Invalid team selection." } });
                }

                NewPerson.Created = DateTime.UtcNow;
                NewPerson.Updated = DateTime.UtcNow;
                NewPerson.Archived = false;

                _context.People.Add(NewPerson);
                await _context.SaveChangesAsync();

                return new JsonResult(new { success = true });
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return new JsonResult(new { success = false, errors = new List<string> { "A database error occurred while saving the person." } });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return new JsonResult(new { success = false, errors = new List<string> { "An unexpected error occurred. Please try again." } });
            }
        }
    }
}
