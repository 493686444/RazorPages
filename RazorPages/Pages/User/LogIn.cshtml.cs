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
        [BindProperty]//注意此处,即便User的内部已经有model验证了,但是这里还要加上绑定才行
        public C.User User { set; get; }
        public C.User DBUser { set; get; }

        [BindProperty]
        public string Captcha { set; get; }

        [BindProperty]
        public bool RememberMe { set; get; }



        public C.SqlDbContext DBContext { set; get; } = new C.SqlDbContext();
        public void OnGet()
        {
            //验证码
            ViewData["captcha"] = "wxyz";
            HttpContext.Session.SetString("captcha","wxyz");

            //是否从其他页面强行重定向过来的
            bool exist = Request.Query.TryGetValue("parameter", out StringValues parameter);
            if (exist)
            {
                ViewData["tooltip"] = "请先登录";
            }
            else
            {
               
            }
        }

        public IActionResult OnPost()
        {
            //检验用户名和密码是否符合规范
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DBUser = DBContext.Users.Where(a => a.Name == User.Name).FirstOrDefault();

            //验证 用户名/密码/验证码 是否正确
            if (DBUser is null)
            {
                ViewData["result"] = "该用户不存在";
                return Page();
            }
            else
            {
                if (User.password != DBUser.password)
                {
                    ViewData["result"] = "密码错误";
                    return Page();
                }
                else
                {
                    if (Captcha != HttpContext.Session.GetString("captcha"))
                    {
                        ViewData["result"] = "验证码错误";
                        return Page();
                    }
                    else
                    {
                        ViewData["result"] = "登录成功";

                        CookieOptions Options;
                        if (RememberMe)
                        {
                            Options = new CookieOptions() { Expires = DateTime.Now.AddDays(14) };
                            //登录页面刚刚加载完成的时候不可以清理缓存,否则页面报错
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
