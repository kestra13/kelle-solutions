using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KelleSolutions.Data;
using KelleSolutions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KelleSolutions.Pages.Actions
{
    public class CreateActionModel : PageModel
    {
        private readonly KelleSolutionsDbContext _context;

        public CreateActionModel(KelleSolutionsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<ActionEntity> ActionEntities { get; set; }

        [BindProperty]
        public ActionEntity ActionEntity { get; set; }

        public async Task OnGetAsync()
        {
            ActionEntities = await _context.ActionEntities.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Log all the validation errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
                return RedirectToPage("./MyActions");
            }
            
            _context.ActionEntities.Add(ActionEntity);
            await _context.SaveChangesAsync();

            Console.WriteLine("Form successfully saved to database.");
            return RedirectToPage("./MyActions");
        }
    }
}