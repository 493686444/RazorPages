using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages.User
{
    [NeedLogOn]
    public class PersonalDateModel : PageModel
    {
        public void OnGet()
        {
        }
        
    
    
    }
}
