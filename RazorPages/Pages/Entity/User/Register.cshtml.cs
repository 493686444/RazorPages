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
            //检验两次密码的输入暂时搁置
            NewUser.Gender = true;//测试补充的内容

            context.Users.Add(NewUser);
            context.SaveChanges();
        }
    }
}
