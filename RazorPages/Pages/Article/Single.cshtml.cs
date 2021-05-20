using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;
using C=RazorPages.Classes;

namespace RazorPages.Pages.Article
{
    public class SingleModel : PageModel
    {
        public SqlDbContext context = new SqlDbContext();
        public C.Article Article { get; set; } = new C.Article();
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["Id"][0]);
            Article = context.Articles.Find(id);
        }
    }
}
