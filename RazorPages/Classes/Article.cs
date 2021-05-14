using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateTime { get; set; }
        public string Author { get; set; }
    }
}

