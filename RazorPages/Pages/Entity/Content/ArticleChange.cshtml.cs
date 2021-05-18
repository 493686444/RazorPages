using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages
{
    public class ArticleChangeModel : PageModel
    {
        SqlDbContext Context { set; get; } = new SqlDbContext();
    
        public int id { set; get; } = 1;//点击之后才会生成id,没有点击只有页面/,所以暂时搁置有 1 代替
        [BindProperty]
        public Article article { get; set; } = new Article();
        public void OnGet()
        {
            article.Id = id;
            article = Context.Articles.Find(article.Id);
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
