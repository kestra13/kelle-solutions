using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;        // handles user authentication!    
using KelleSolutions.Models;                // import model classes
using KelleSolutions.Data;                  // imports KelleSolutionsDbContext.cs
using System.Threading.Tasks;               // supports non-blocking queries (ex: "async", "wait")
using System;




namespace KelleSolutions.Pages.People {
    public class CreatePersonModel : PageModel {
        private readonly UserManager<User> _userManager;
        private readonly KelleSolutionsDbContext _context;

        public CreatePersonModel(UserManager<User> userManager, KelleSolutionsDbContext context) {
            _userManager = userManager;
            _context = context;

            // initialize an empty person object with default values
            Person = new Person {
                Name_First = string.Empty,
                Name_Middle = string.Empty,
                Name_Last = string.Empty,
                Name_Display = string.Empty,
                Email_Primary = string.Empty,
                Email_Secondary = string.Empty,
                Phone_Primary = string.Empty,
                Phone_Secondary = string.Empty,
                Country = string.Empty,
                StateProvince = string.Empty,
                City = string.Empty,
                Postal = string.Empty,
                Street = string.Empty,
                Bio = string.Empty,
                Comments = string.Empty,
                Created = DateTime.UtcNow,  // automatically set creation date
                Updated = DateTime.UtcNow,  // automatically set update date
                Archived = false,           // default: Not archived
                Verified = false,           // default: Not verified
                VIP = false                 // default: Not VIP
            };
        }

        // property to bind the form input to the Person object
        [BindProperty]
        public Person Person { get; set; }

        // handling the GET requests (shows the empty form)
        public IActionResult OnGet() {
            return Page();
        }

        // handles the POST requests (form submission)
        public async Task<IActionResult> OnPostAsync() {
            // check if the submitted data is NOT valid based on Person.cs's validation rules
            if (!ModelState.IsValid) {
                // return the page with validation errors
                return Page();
            }

            try {
                // get the currently logged-in user
                var currentUser = await _userManager.GetUserAsync(User);
            
                if (currentUser != null) {
                    // if Operator represents the creator, and User ID is an integer, cast it safely
                    if (short.TryParse(currentUser.Id.ToString(), out short operatorId)) {
                        Person.Operator = operatorId;
                    }
                    else {
                        // handle case where User ID cannot be converted to short
                        ModelState.AddModelError("", "Failed to assign Operator ID.");
                        return Page();
                    }
                }
                else {
                    ModelState.AddModelError("", "User not found. Please log in.");
                    return Page();
                }
                // assign a default or user-selected Team value 
                Person.Team = 1;

                // set timestamps
                Person.Created = DateTime.UtcNow;
                Person.Updated = DateTime.UtcNow;

                // save new Person to the database
                _context.People.Add(Person);
                await _context.SaveChangesAsync();

                // redirect to the People list after successful creation
                return RedirectToPage("/People/People");

            }
            catch (Exception ex)
            {
                // log error and display a generic error message
                ModelState.AddModelError("", "An error occurred while trying to save! Please try again.");
                Console.WriteLine($"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
