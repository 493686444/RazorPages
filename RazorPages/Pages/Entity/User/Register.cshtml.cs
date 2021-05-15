using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages
{
    public class RegisterModel : PageModel
    {
        public SqlDbContext context { set; get; }
        public User User { set; get; }
        public string SecondPassword { set; get; }
        public void OnGet()
        {
        }
    }
}
