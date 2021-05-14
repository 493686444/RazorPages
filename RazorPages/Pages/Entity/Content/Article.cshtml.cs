using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages.Entity.Content
{
    public class ArticleModel : PageModel
    {
        public List<Article> NewArticles = new List<Article>();

        public SqlDbContext context { set; get; }

        [BindProperty]
        public int pageIndex { set; get; } = 0;
        public List<Article> viewArticles { get; set; } = new List<Article>();

        public ArticleModel()
        {
            context = new SqlDbContext();

        }
        public void OnGet()
        {
            ////这是找多个的时候
            pageIndex = Convert.ToInt32(Request.Query["pageIndex"]);
            Article One = new Article() { Title = "onetitle", Body = "onebody", Author = "oneauthor" };
            Article Two = new Article() { Title = "twotitle", Body = "twobody", Author = "twoauthor" };
            Article Three = new Article() { Title = "3title", Body = "threebody", Author = "threeauthor" };
            Article four = new Article() { Title = "4title", Body = "threebody", Author = "threeauthor" };
            Article five = new Article() { Title = "5title", Body = "threebody", Author = "threeauthor" };
            //SqlDbContext context = new SqlDbContext();
            //context.Articles.AddRange(One, Two, Three);
            //context.SaveChanges();
            NewArticles.Add(One);
            NewArticles.Add(Two);
            NewArticles.Add(Three);
            NewArticles.Add(four);
            NewArticles.Add(five);
            viewArticles= NewArticles.Skip(pageIndex*2).Take(2).ToList();

            ////这是找一个的时候
            //int id = Convert.ToInt32(Request.Query["id"][0]);
            //article = context.Articles.Find(id);
           
        }
        public void OnPost() 
        {
          
        }
    }
}
