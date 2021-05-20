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
    public class IndexModel : PageModel
    {
        public int pageIndex { set; get; }
        private SqlDbContext context { set; get; } = new SqlDbContext();
        public List<C.Article> AllArticles = new List<C.Article>();
        public List<C.Article> PageArticles { get; set; } = new List<C.Article>();

        public void OnGet()
        {
            pageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);
            AllArticles = context.Articles.Where(a => a.Title != null).ToList();
            PageArticles = AllArticles.Skip(pageIndex*4).Take(4).ToList();
        }
        public void OnPost() 
        {
         
        }
    }
}
