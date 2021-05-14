using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages
{
    public class ArticleListModel : PageModel
    {
        public List<Article> NewArticles = new List<Article>();
        public SqlDbContext context { set; get; }
        public int pageIndex { set; get; } = 0;
        public List<Article> viewArticles { get; set; } = new List<Article>();

        public ArticleListModel()
        {
            context = new SqlDbContext();

        }
        public void OnGet()
        {
            pageIndex = Convert.ToInt32(Request.Query["pageIndex"]);
            NewArticles = context.Articles.Where(a => a.Title != null).ToList();
           
            viewArticles = NewArticles.Skip(pageIndex*4).Take(4).ToList();

            ////这是找一个的时候
            //int id = Convert.ToInt32(Request.Query["id"][0]);
            //article = context.Articles.Find(id);
           
        }
        public void OnPost() 
        {
         
        }
    }
}
