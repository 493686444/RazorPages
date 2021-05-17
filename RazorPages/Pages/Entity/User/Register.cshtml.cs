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
        public void OnPost() 
        {
            if (!ModelState.IsValid)
            { 
                return;
            }
            
            if (context.Users.Where(u=>u.Name== NewUser.Name).Select(u=>u.Name).ToList().Contains( NewUser.Name )) //�˴�ʹ��linq�﷨����
            {
                ViewData["Error"] = "�Ѵ��ڸ��û�";
                return;
            }/*else nothing*/
            

            context.Users.Add(NewUser);
            context.SaveChanges();
        }
    }
}
