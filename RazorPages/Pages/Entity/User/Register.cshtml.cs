using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages
{
    public class RegisterModel : PageModel
    {
        public SqlDbContext context { set; get; } = new SqlDbContext();
        [BindProperty]
        public User NewUser { set; get; } = new User();
        public string SecondPassword { set; get; }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            { 
                return Page();
            }
            if (context.Users
                .Where(u=>u.Name== NewUser.Name)
                .Select(u=>u.Name)
                .ToList()
                .Contains( NewUser.Name )) //此处使用linq语法更简单
            {
                ViewData["Error"] = "已存在该用户";
                return Page();
            }/*else nothing*/

            context.Users.Add(NewUser);
            context.SaveChanges();

            Response.Cookies.Append("User.Name", NewUser.Name.ToString());
            Response.Cookies.Append("User.password", NewUser.password.ToString());

            return RedirectToPage("/Entity/User/Login");
        }
    }
}
