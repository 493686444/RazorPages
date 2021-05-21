using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using C = RazorPages.Classes;

namespace RazorPages.Pages.User
{
    public class LogInModel : PageModel
    {
        [BindProperty]//ע��˴�,����User���ڲ��Ѿ���model��֤��,�������ﻹҪ���ϰ󶨲���
        public C.User User { set; get; }
        public C.User DBUser { set; get; }

        [BindProperty]
        public string Captcha { set; get; }

        [BindProperty]
        public bool RememberMe { set; get; }



        public C.SqlDbContext DBContext { set; get; } = new C.SqlDbContext();
        public void OnGet()
        {
            //��֤��
            ViewData["captcha"] = "wxyz";
            HttpContext.Session.SetString("captcha","wxyz");

            //�Ƿ������ҳ��ǿ���ض��������
            bool exist = Request.Query.TryGetValue("parameter", out StringValues parameter);
            if (exist)
            {
                ViewData["tooltip"] = "���ȵ�¼";
            }
            else
            {
               
            }
        }

        public IActionResult OnPost()
        {
            //�����û����������Ƿ���Ϲ淶
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DBUser = DBContext.Users.Where(a => a.Name == User.Name).FirstOrDefault();

            //��֤ �û���/����/��֤�� �Ƿ���ȷ
            if (DBUser is null)
            {
                ViewData["result"] = "���û�������";
                return Page();
            }
            else
            {
                if (User.password != DBUser.password)
                {
                    ViewData["result"] = "�������";
                    return Page();
                }
                else
                {
                    if (Captcha != HttpContext.Session.GetString("captcha"))
                    {
                        ViewData["result"] = "��֤�����";
                        return Page();
                    }
                    else
                    {
                        ViewData["result"] = "��¼�ɹ�";

                        CookieOptions Options;
                        if (RememberMe)
                        {
                            Options = new CookieOptions() { Expires = DateTime.Now.AddDays(14) };
                            //��¼ҳ��ոռ�����ɵ�ʱ�򲻿���������,����ҳ�汨��
                        }
                        else
                        {
                            Options = new CookieOptions() { Expires = DateTime.Now.AddDays(1) };
                        }
                        Response.Cookies.Append("User.Name", DBUser.Name.ToString(), Options);

                        bool result = Request.Query.TryGetValue("parameter", out StringValues parameter);
                        if (result)
                        {
                            return RedirectToPage(parameter);
                        }
                        else
                        {
                            return Page();
                        }
                    }
                }
            }
        
           
          
        }
    }
}
