using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace KelleSolutions.Pages.Leads
{
    public class LeadsModel : PageModel
    {
        public List<UserLeads> UserLeads {get;set;}

        public void OnGet()
        {
            // Static list of users for demonstration.
            UserLeads = new List<UserLeads>
            {
                //place holder for now but have to update this later to retrieve all users from the same group
                new UserLeads
                { 
                    Id = 1,
                    UserName = "Randall Watts",
                },
                new UserLeads
                { 
                    Id = 2,
                    UserName = "Luis Gallarzo",
                }
            };
        }
    }

    public class UserLeads
    {
        public int Id { get; set; }
        public string ? UserName {get;set;}
    }
}
