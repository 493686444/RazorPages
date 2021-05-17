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
        [BindProperty]//注意此处,即便User的内部已经有model验证了,但是这里还要加上绑定才行
        public C.User User { set; get; }
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
            DBUser = context.Users.Where(a => a.Name == User.Name).FirstOrDefault();

            if (DBUser is null)
            {
                ViewData["result"] = "该用户不存在";
            }
            else
            {
                if (User.password == DBUser.password)
                {
                    ViewData["result"] = "登录成功";
                }
                else
                {
                    ViewData["result"] = "密码错误";
                }
            }

            if (RememberMe)
            {
                CookieOptions Options = new CookieOptions() { Expires = DateTime.Now.AddDays(14) };
                Response.Cookies.Append("User.Name", DBUser.Name.ToString(), Options);  //登录页面刚刚加载完成的时候不可以清理缓存,否则页面报错
            }

        }
    }
}
