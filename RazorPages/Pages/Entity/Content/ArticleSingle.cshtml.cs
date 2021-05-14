using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages
{
    public class ArticleSingleModel : PageModel
    {
        public SqlDbContext context = new SqlDbContext();
        public Article Article { get; set; } = new Article();
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["id"][0]);
            Article=context.Articles.Find(id);
        }
    }
}
