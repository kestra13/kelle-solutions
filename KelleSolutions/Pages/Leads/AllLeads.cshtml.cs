using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using KelleSolutions.Data;
using KelleSolutions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace KelleSolutions.Pages.Leads
{
    public class AllLeadsModel : PageModel {
        private readonly KelleSolutionsDbContext _context;

        private readonly UserManager<User> _userManager;
        public CreateLeadModel CreateLeadModel { get; set; }
        public AllLeadsModel(KelleSolutionsDbContext context, UserManager<User> userManager)
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

        // Bind the Lead model to the form
        [BindProperty]
        public Lead Lead { get; set; }

        // Updated to use the new Property model fields.
        public List<Lead> AllLeads { get; set; } = new();


        public async Task OnGetAsync() {
            AllLeads = await _context.Leads
                .Where(l => !l.Archived)
                .OrderBy(l => l.NameFirst)
                .ToListAsync();

        }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }
        public async Task<JsonResult> OnPostCreateListingAsync()
        {
            try
            {
                //Enable buffering so we can read the request body multiple times
                Request.EnableBuffering();
                string body;
                using(var reader = new StreamReader(Request.Body, leaveOpen: true))
                {
                    body = await reader.ReadToEndAsync();
                }
                //Reset the stream position for any further reads.
                Request.Body.Position = 0;

                if (string.IsNullOrWhiteSpace(body))
                {
                    return new JsonResult(new { success = false, message = "Empty request body" });
                }

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                CreateLeadInputModel input;
                try
                {
                    input = JsonSerializer.Deserialize<CreateLeadInputModel>(body, options);
                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, message = "Invalid JSON: " + ex.Message });
                }

                if (input == null || string.IsNullOrWhiteSpace(input.FirstName) ||
                    string.IsNullOrWhiteSpace(input.MiddleName) || string.IsNullOrWhiteSpace(input.LastName) ||
                    string.IsNullOrWhiteSpace(input.LastName) || string.IsNullOrWhiteSpace(input.Email) ||
                    string.IsNullOrWhiteSpace(input.Phone) || string.IsNullOrWhiteSpace(input.Country) ||
                    string.IsNullOrWhiteSpace(input.StateProvince) || string.IsNullOrWhiteSpace(input.City) ||
                    string.IsNullOrWhiteSpace(input.Postal) || string.IsNullOrWhiteSpace(input.Street) ||
                    string.IsNullOrWhiteSpace(input.OrganizationName)|| string.IsNullOrWhiteSpace(input.OrginzationTitle) ||
                    string.IsNullOrWhiteSpace(input.Tracking))
                {
                    return new JsonResult(new { success = false, message = "Missing required fields" });
                }
                //Create new leads and set all Required fields
                Lead newLeads = new Lead {
                    NameFirst = input.FirstName,
                    NameMiddle = input.MiddleName,
                    NameLast = input.LastName,
                    Email = input.Email,
                    Phone = input.Phone,
                    Country = input.Country,
                    StateProvince = input.StateProvince,
                    City = input.City,
                    Postal = input.Postal,
                    Street = input.Street,
                    OrganizationName = input.OrganizationName,
                    OrganizationTitle = input.OrginzationTitle,
                    Tracking = input.Tracking,
                    //set default values for required leads not provided by the form
                    Archived = false,
                    Operator = 0,
                    Originator = 0,
                    Team = 0,
                    Visibility = 0,
                    StageWorked = false,
                    TempWarm = false,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                };
                _context.Leads.Add(newLeads);
                await _context.SaveChangesAsync();
                return new JsonResult(new {success=true});
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Unhandled error: " + ex.ToString() });
            }
        }
        public async Task<IActionResult> OnPostUpdateAsync(int id) {
            var lead = await _context.Leads.FindAsync(id);
            if(lead == null) {
                return NotFound();
            }
            
            try {
                lead.NameFirst = Request.Form["NameFirst"]!;
                lead.NameMiddle = Request.Form["NameMiddle"]!;
                lead.NameLast = Request.Form["NameLast"]!;
                lead.Email = Request.Form["Email"]!;
                lead.Phone = Request.Form["Phone"]!;
                lead.Country = Request.Form["Country"]!;
                lead.StateProvince = Request.Form[".StateProvince"]!;
                lead.City = Request.Form["City"]!;
                lead.Postal = Request.Form["Postal"]!;
                lead.Street = Request.Form["Street"]!;
                lead.OrganizationName = Request.Form["OrganizationName"]!;
                lead.OrganizationTitle = Request.Form["OrganizationTitle"]!;
                lead.Tracking = Request.Form["Tracking"]!;
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            catch (Exception e) {
                AllLeads = await _context.Leads
                    .Where(e => !e.Archived)
                    .OrderBy(e => e.NameFirst)
                    .ToListAsync();
                ModelState.AddModelError("", "Error updating the lead. Please try again.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id) {
            var lead = await _context.Leads.FindAsync(id);
            if(lead == null) {
                return NotFound();
            }
            try {
                lead.Archived =true;
                lead.Updated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            catch(Exception e) {
                ModelState.AddModelError("", "Error deleting the lead. Please try again.");
                return Page();
            }
        }
    }
    public class CreateLeadInputModel {
        public string ? FirstName {get;set;}
        public string ? MiddleName {get;set;}
        public string ? LastName {get;set;}
        public string ? Email {get;set;}
        public string? Phone {get;set;}
        public string? Country {get;set;}
        public string ? StateProvince {get;set;}
        public string ? City {get;set;}
        public string ? Postal {get;set;}
        public string ? Street {get;set;}
        public string ? OrganizationName {get;set;}
        public string ? OrginzationTitle {get;set;}
        public string ? Tracking {get;set;}
    }

}