using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.User
{
    public class LogOffModel : PageModel
    {

        public IActionResult OnGet()
        {
            Response.Cookies.Delete("User.Name");
            return Redirect($"/User/LogIn?parameter={HttpContext.Request.Path.Value}");
        }
    }
}
