using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C = RazorPages.Classes;

namespace RazorPages.Pages.Entity
{
    public class LoginModel : PageModel
    {
        [BindProperty]//ע��˴�,����User���ڲ��Ѿ���model��֤��,�������ﻹҪ���ϰ󶨲���
        public C.User NewUser { set; get; }
        public C.User DBUser { set; get; }

        public string AuthCode { set; get; }

        [BindProperty]
        public bool RememberMe { set; get; }



        public C.SqlDbContext context { set; get; } = new C.SqlDbContext();
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            DBUser = context.Users.Where(a => a.Name == NewUser.Name).FirstOrDefault();

            if (DBUser is null)
            {
                ViewData["result"] = "���û�������";
            }
            else
            {
                if (NewUser.password == DBUser.password)
                {
                    ViewData["result"] = "��¼�ɹ�";
                }
                else
                {
                    ViewData["result"] = "�������";
                }
            }

            if (RememberMe)
            {
                CookieOptions Options = new CookieOptions() { Expires = DateTime.Now.AddDays(14) };
                Response.Cookies.Append("UserId", DBUser.Id.ToString(), Options);
            }

        }
    }
}
