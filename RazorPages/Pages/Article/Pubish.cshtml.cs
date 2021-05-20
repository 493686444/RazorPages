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
    [NeedLogOn]
    public class PubishModel : PageModel
    {
        SqlDbContext Context { set; get; } = new SqlDbContext();
        [BindProperty]
        public C.Article article { get; set; } = new C.Article();
        public void OnGet( )
        {
            
        }
        public void OnPost( )
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            Context.Articles.Add(article);
            Context.SaveChanges();
        }
    }
}
