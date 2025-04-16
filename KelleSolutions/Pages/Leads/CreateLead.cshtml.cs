using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KelleSolutions.Models;
using KelleSolutions.Data;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;

namespace KelleSolutions.Pages.Leads
{
    public class CreateLeadModel : PageModel
    {
        private readonly KelleSolutionsDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateLeadModel(KelleSolutionsDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            // Initialize a new Lead instance using the updated properties.
            Lead = new Lead {
                NameFirst = string.Empty,
                NameMiddle = string.Empty,
                NameLast = string.Empty,
                Email = string.Empty,
                Phone = string.Empty,
                Country = string.Empty,
                StateProvince = string.Empty,
                City = string.Empty,
                Postal = string.Empty,
                Street = string.Empty,
                OrganizationName = string.Empty,
                OrganizationTitle = string.Empty,
                Tracking = string.Empty
            };
        }

        [BindProperty]
        public Lead Lead { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach(var state in ModelState)
                    {
                        foreach(var error in state.Value.Errors) {
                            Console.WriteLine($"Error in {state.Key}: {error.ErrorMessage}");
                            ModelState.AddModelError("", $"Error in {state.Key}: {error.ErrorMessage}");
                        }
                    }
                    return Page();
                }
                var currentUser = await _userManager.GetUserAsync(User);
                // Add debugging line here to check TenantID
                Console.WriteLine($"Current user TenantID: {currentUser?.TenantID}");

                var userRoles = await _userManager.GetRolesAsync(currentUser);
                string userRole = userRoles.FirstOrDefault();

                //set default values for required leads not provided by the form
                Lead.Archived = false;
                Lead.Operator = 0;
                Lead.Originator = 0;
                Lead.Team = 0;
                Lead.Visibility = 0;
                Lead.StageWorked = false;
                Lead.TempWarm = false;
                Lead.Created = DateTime.UtcNow;
                Lead.Updated = DateTime.UtcNow;

                _context.Leads.Add(Lead);
                await _context.SaveChangesAsync();
                // Redirect back to the MyLeads page so the new lead is visible.
                return RedirectToPage("/Leads/MyLeads");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error saving Lead: {ex.Message}");
                return Page();
            }
        }
    }
}
