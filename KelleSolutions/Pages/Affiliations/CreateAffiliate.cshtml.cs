using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KelleSolutions.Data;
using KelleSolutions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KelleSolutions.Pages.Affiliations
{
    public class CreateAffiliateModel : PageModel
    {
        private readonly KelleSolutionsDbContext _context;

        // List of affiliates
        public IList<Affiliate> Affiliates { get; set; }

        // Model to hold new or edited affiliate data
        [BindProperty]
        public Affiliate NewAffiliate { get; set; }

        public CreateAffiliateModel(KelleSolutionsDbContext context)
        {
            _context = context;
        }

        // OnGet to display the list of affiliates
        public async Task OnGetAsync()
        {
            Affiliates = await _context.Affiliates.ToListAsync();
            NewAffiliate = new Affiliate();  // Ensure NewAffiliate is initialized
        }

        // OnPostCreate to add a new affiliate to the database
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (ModelState.IsValid)
            {
                // Ensure the Id is unique
                var existingAffiliate = await _context.Affiliates.FindAsync(NewAffiliate.Id);
                if (existingAffiliate != null)
                {
                    ModelState.AddModelError("NewAffiliate.Id", "The ID already exists.");
                    return Page(); // Return to the form with an error
                }

                // Set CreatedDate to current time if not set already
                NewAffiliate.CreatedDate = NewAffiliate.CreatedDate == default ? DateTime.Now : NewAffiliate.CreatedDate;

                _context.Affiliates.Add(NewAffiliate);
                await _context.SaveChangesAsync();
                return RedirectToPage(); // Reload the page to show the updated list
            }
            return Page();
        }

        // OnGetEdit to show the form for editing an existing affiliate
        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            NewAffiliate = await _context.Affiliates.FindAsync(id);
            if (NewAffiliate == null)
            {
                return NotFound();
            }
            return Page();
        }

        // OnPostUpdate to save changes when editing an affiliate
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Attach(NewAffiliate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            return Page();
        }

        // OnPostDelete to delete an affiliate
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var affiliate = await _context.Affiliates.FindAsync(id);
            if (affiliate != null)
            {
                _context.Affiliates.Remove(affiliate);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
        
    }
}
