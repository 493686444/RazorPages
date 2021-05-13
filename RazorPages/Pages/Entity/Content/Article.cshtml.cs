using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Pages.Classes;

namespace RazorPages.Pages.Entity.Content
{
    public class ArticleModel : PageModel
    {
        public SqlDbContext context { set; get; } = new SqlDbContext();
        public Article article { get; set; } = new Article();
        public void OnGet()
        {
            //int id = Convert.ToInt32(Request.Query["id"][0]);
            //article = context.Articles.Find(id);
        }
    }
}
