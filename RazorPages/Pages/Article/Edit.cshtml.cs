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
    public class EditModel : PageModel
    {
        SqlDbContext Context { set; get; } = new SqlDbContext();

        public int id { set; get; } = 1;
        [BindProperty]
        public C.Article article { get; set; } = new C.Article();
        public void OnGet()
        {
            article.Id = id;
            article = Context.Articles.Find(article.Id);
            ViewData["parameter"] = "/Article/Edit";
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            article.Id = id;
            Context.Articles.Update(article);
            Context.SaveChanges();
        }
    }
}
