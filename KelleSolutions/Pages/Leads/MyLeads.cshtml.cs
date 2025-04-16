using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KelleSolutions.Data;
using KelleSolutions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace KelleSolutions.Pages.Leads
{
    public class ViewLeadsModel : PageModel
    {
        private readonly KelleSolutionsDbContext _context;

        public ViewLeadsModel(KelleSolutionsDbContext context)
        {
            _context = context;
        }

        // Updated view model to include additional properties
        public List<ViewUserLeads> AllLeads { get; set; }
        public List<ViewUserLeads> ViewUserLeads { get; set; }

        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public int TotalPages => (int)Math.Ceiling((double)AllLeads.Count / PageSize);

        public async Task OnGetAsync(int PageNumber = 1, int PageSize = 10)
        {
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;

            // Fetch leads from the database and project to the view model.
            AllLeads = await _context.Leads
                .AsNoTracking()
                .OrderByDescending(l => l.Created)
                .Select(l => new ViewUserLeads
                {
                    // Assuming that l.Code is your unique identifier (cast to int if necessary)
                    ID = (int)l.Code,
                    CreationDate = l.Created.HasValue ? DateOnly.FromDateTime(l.Created.Value) : DateOnly.MinValue,
                    // You can display a full name by concatenating first, middle (if any), and last names.
                    FullName = l.NameFirst + " " + (string.IsNullOrWhiteSpace(l.NameMiddle) ? "" : l.NameMiddle + " ") + l.NameLast,
                    Phone = l.Phone,
                    Email = l.Email,
                    Country = l.Country,
                    StateProvince = l.StateProvince,
                    City = l.City,
                    Postal = l.Postal,
                    Street = l.Street,
                    OrganizationName = l.OrganizationName,
                    OrganizationTitle = l.OrganizationTitle,
                    Tracking = l.Tracking
                })
                .ToListAsync();

            // Apply pagination (this example uses all the leads; you can later filter by signed-in user if needed)
            ViewUserLeads = AllLeads
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }

    // Expand the view model class to include more fields.
    public class ViewUserLeads
    {
        public int ID { get; set; }
        public DateOnly CreationDate { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Street { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationTitle { get; set; }
        public string Tracking { get; set; }
    }
}
