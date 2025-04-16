using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public CreateActionModel(KelleSolutionsDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public string FirstName { get; set; }

        [BindProperty]
        public List<ActionEntity> ActionEntities { get; set; }

        [BindProperty]
        public ActionEntity ActionEntity { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool ShowImportant { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool ShowCompleted { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public bool SortAscending { get; set; }

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            FirstName = currentUser?.FirstName ?? "User";

            var query = _context.ActionEntities.AsQueryable();
            
            if (ShowImportant)
            {
                query = query.Where(a => a.Important);
            }

            if (!ShowCompleted)
            {
                query = query.Where(a => !a.Completed);
            }

            query = SortAscending 
                ? query.OrderBy(a => a.Due) 
                : query.OrderByDescending(a => a.Due);
            
            ActionEntities = await query.ToListAsync();
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

        public async Task<IActionResult> OnPostCompleteAsync(int actionId, bool? isCompleted)
        {
            var action = await _context.ActionEntities.FindAsync(actionId);
            if (action == null)
            {
                return NotFound();
            }

            action.Completed = isCompleted ?? false;
            await _context.SaveChangesAsync();

            return RedirectToPage(); // reloads the current page
        }
    }
}