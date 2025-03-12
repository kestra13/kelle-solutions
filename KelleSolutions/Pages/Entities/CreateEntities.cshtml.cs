using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KelleSolutions.Data;
using KelleSolutions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KelleSolutions.Pages.Entities
{
    public class CreateEntitiesModel : PageModel
    {
        private readonly KelleSolutionsDbContext _context;

        public CreateEntitiesModel(KelleSolutionsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entity Entity { get; set; } = new();

        public List<Category> Categories { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            if (!Categories.Any())
            {
                ModelState.AddModelError("", "No categories found in the system. Please add categories first.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure required fields are populated
            if (string.IsNullOrWhiteSpace(Entity.EntityName) ||
                Entity.Category == 0 ||
                string.IsNullOrWhiteSpace(Entity.Phone) ||
                string.IsNullOrWhiteSpace(Entity.City) ||
                string.IsNullOrWhiteSpace(Entity.StateProvince) ||
                string.IsNullOrWhiteSpace(Entity.Country) ||
                string.IsNullOrWhiteSpace(Entity.Postal) ||
                string.IsNullOrWhiteSpace(Entity.Street))
            {
                ModelState.AddModelError("", "All required fields must be filled.");
                return Page();
            }

            // Set Created/Updated timestamps
            Entity.Created = DateTime.UtcNow;
            Entity.Updated = DateTime.UtcNow;

            // Convert empty strings to null for optional fields
            Entity.Operator = Entity.Operator == 0 ? null : Entity.Operator;
            Entity.Visibility = Entity.Visibility == 0 ? null : Entity.Visibility;
            Entity.MySource = Entity.MySource == 0 ? null : Entity.MySource;
            Entity.Name_Display = string.IsNullOrWhiteSpace(Entity.Name_Display) ? null : Entity.Name_Display;
            Entity.Headline = string.IsNullOrWhiteSpace(Entity.Headline) ? null : Entity.Headline;
            Entity.Phone_Secondary = string.IsNullOrWhiteSpace(Entity.Phone_Secondary) ? null : Entity.Phone_Secondary;
            Entity.Phone_Primary_Label = string.IsNullOrWhiteSpace(Entity.Phone_Primary_Label) ? null : Entity.Phone_Primary_Label;
            Entity.Phone_Secondary_Label = string.IsNullOrWhiteSpace(Entity.Phone_Secondary_Label) ? null : Entity.Phone_Secondary_Label;
            Entity.Tracking = string.IsNullOrWhiteSpace(Entity.Tracking) ? null : Entity.Tracking;
            Entity.Comments = string.IsNullOrWhiteSpace(Entity.Comments) ? null : Entity.Comments;
            Entity.Website = string.IsNullOrWhiteSpace(Entity.Website) ? null : Entity.Website;
            Entity.Bio = string.IsNullOrWhiteSpace(Entity.Bio) ? null : Entity.Bio;

            // get teams
            var teams = await _context.Teams.ToListAsync();

            // get categories
            var categories = await _context.Categories.ToListAsync();

            // Save to database
            _context.Entities.Add(Entity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Entities", new { reload = true });
        }

    }
}
