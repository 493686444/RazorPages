using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C=RazorPages.Classes;

namespace RazorPages.Pages.Entity
{
    public class LoginModel : PageModel
    {
        public string UserName { set; get;}
        public string PassWord { set; get; }
        public string AuthCode { set; get; }
       
        public C.SqlDbContext context { set; get; }
        public C.User User { set; get; }
        public void OnGet()
        {

        }
    }
}
