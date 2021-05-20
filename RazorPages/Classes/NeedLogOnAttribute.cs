using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class NeedLogOnAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool existing = context.HttpContext.Request.Cookies.TryGetValue("User.Name", out string userName);
            if (existing)
            {

            }
            else
            {
                context.Result = new RedirectResult($"/Entity/User/Login?parameter={context.HttpContext.Request.Path.Value}");
            }
        }
    }
}
