using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace KelleSolutions.Pages.Properties
{
    public class PropertiesModel : PageModel
    {
        public List<UserProperties> UserProperties { get; set; }

        public void OnGet()
        {
            // Static list of users for demonstration.
            UserProperties = new List<UserProperties>
            {
                new UserProperties 
                { 
                    Id = 1,
                    UserName = "Randall Watts",
                    PeopleCount = 3
                },
                new UserProperties 
                { 
                    Id = 2,
                    UserName = "Luis Gallarzo",
                    PeopleCount = 2
                }
            };
        }
    }

    public class UserProperties
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        // Renamed PeopleCount to Property Count for clarity.
        public int PeopleCount { get; set; }
    }
}
