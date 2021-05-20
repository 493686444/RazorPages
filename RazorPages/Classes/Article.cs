using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class Article
    {
        public Article()
        {
            CreateTime = DateTime.Now;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "标题不可为空")]
        public string Title { get; set; }

        [Required(ErrorMessage = "内容不可为空")]
        public string Body { get; set; }  
        public DateTime CreateTime { get; set; }
        public User Author { get; set; }
       public Keyword ArticleKeyWord { set; get; }
    }
}

