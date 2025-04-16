using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using KelleSolutions.Models;
using System.Threading.Tasks;

namespace KelleSolutions.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<IndexModel> _logger;

        // Add UserManager to constructor injection
        public IndexModel(ILogger<IndexModel> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        // Changed to async Task and proper null check
        public async Task<IActionResult> OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)  // Correct null check
            {
                return RedirectToPage("/admin/adminDashboard");
            }
            
            return Page();  // Return Page() if user is null
        }
    }
}