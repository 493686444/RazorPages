using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class UnAppearModel : PageModel
    {

        public IActionResult OnGet()
        {
            Response.Cookies.Append("UnAppear", "true");
            return Redirect(Request.Headers["referer"]);
        }
    }
}
