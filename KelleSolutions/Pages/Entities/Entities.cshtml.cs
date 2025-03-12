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
    public class EntitiesModel : PageModel
    {
        private readonly KelleSolutionsDbContext _context;

        public EntitiesModel(KelleSolutionsDbContext context)
        {
            _context = context;
        }

        public List<Entity> Entities { get; set; } = new();
        public List<Category> Categories { get; set; } = new();

        public async Task OnGetAsync(bool reload = false)
        {
            Entities = await _context.Entities
                .Select(e => new Entity
                {
                    Code = e.Code,
                    EntityName = e.EntityName,
                    Category = e.Category,
                    Phone = e.Phone,
                    City = e.City,
                    StateProvince = e.StateProvince,
                    Country = e.Country,
                    Postal = e.Postal,
                    Street = e.Street,
                    Created = e.Created,
                    Updated = e.Updated,
                    Archived = e.Archived,
                    Bio = e.Bio,
                    Comments = e.Comments,
                    Website = e.Website,
                    Visibility = e.Visibility,
                    DoNot_Market = e.DoNot_Market,
                    DoNot_Contact = e.DoNot_Contact,
                    Team = e.Team
                })
                .ToListAsync();

                if (reload)
                {
                    Console.WriteLine("Page reloaded after entity creation.");
                }

        }



        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound(new { success = false, message = "Entity not found." });
            }

            if (string.IsNullOrWhiteSpace(Request.Form["EntityName"]) ||
                string.IsNullOrWhiteSpace(Request.Form["Phone"]) ||
                string.IsNullOrWhiteSpace(Request.Form["City"]) ||
                string.IsNullOrWhiteSpace(Request.Form["StateProvince"]) ||
                string.IsNullOrWhiteSpace(Request.Form["Country"]))
            {
                return BadRequest(new { success = false, message = "All required fields must be filled." });
            }

            // Assign values only if they exist in the request
            if (!string.IsNullOrEmpty(Request.Form["EntityName"]))
                entity.EntityName = Request.Form["EntityName"];

            if (short.TryParse(Request.Form["Category"], out var category))
                entity.Category = category;

            if (!string.IsNullOrEmpty(Request.Form["Phone"]))
                entity.Phone = Request.Form["Phone"];

            if (!string.IsNullOrEmpty(Request.Form["City"]))
                entity.City = Request.Form["City"];

            if (!string.IsNullOrEmpty(Request.Form["StateProvince"]))
                entity.StateProvince = Request.Form["StateProvince"];

            if (!string.IsNullOrEmpty(Request.Form["Country"]))
                entity.Country = Request.Form["Country"];

            // Update timestamp
            entity.Updated = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true, message = "Entity updated successfully." });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound(new { success = false, message = "Entity not found." });
            }

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true, message = "Entity deleted successfully." });
        }
    }
}
