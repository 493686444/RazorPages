using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C = RazorPages.Classes;

namespace RazorPages.Pages.User
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public C.User User { get; set; }
        public void OnGet()
        {
            User = new C.User();
            User.Id = Convert.ToInt32(Request.Query["Id"][0]);
            User.Name = "HJB";
        }
    }
}
