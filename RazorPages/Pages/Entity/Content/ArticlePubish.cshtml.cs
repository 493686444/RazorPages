using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages
{
    public class ArticlePublishModel: PageModel
    {
        SqlDbContext Context { set; get; } = new SqlDbContext();
        [BindProperty]
        public Article article { get; set; } = new Article();
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
