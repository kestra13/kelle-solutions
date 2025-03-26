using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using KelleSolutions.Data;
using KelleSolutions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KelleSolutions.Pages.Leads
{
    public class AllLeadsModel : PageModel {
        private readonly KelleSolutionsDbContext _context;

        
        public AllLeadsModel(KelleSolutionsDbContext context) {
            _context = context;
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

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync() {
            
            var query = _context.Leads.AsQueryable();

            int totalLeads = await query.CountAsync();
            TotalPages = (int)System.Math.Ceiling((double)totalLeads / PageSize);

            AllLeads = await query
                .Skip((PageNumber -1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return Page();
        }
    }

}