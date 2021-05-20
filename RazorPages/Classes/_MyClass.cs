using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class _MyClass : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
