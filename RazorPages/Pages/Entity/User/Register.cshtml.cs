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
        [BindProperty]
        public SqlDbContext context { set; get; } = new SqlDbContext();
        [BindProperty]
        public User NewUser { set; get; } = new User();
        public string SecondPassword { set; get; }
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            //�������������������ʱ����
            NewUser.Gender = true;//���Բ��������

            context.Users.Add(NewUser);
            context.SaveChanges();
        }
    }
}
