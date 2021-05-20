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
        private SqlDbContext context { set; get; } = new SqlDbContext();
        public List<C.Article> NewArticles = new List<C.Article>();
        public int pageIndex { set; get; }
        public List<C.Article> viewArticles { get; set; } = new List<C.Article>();

        public void OnGet()
        {
            pageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);
            NewArticles = context.Articles.Where(a => a.Title != null).ToList();
            viewArticles = NewArticles.Skip(pageIndex*4).Take(4).ToList();

        }
        public void OnPost() 
        {
         
        }
    }
}
