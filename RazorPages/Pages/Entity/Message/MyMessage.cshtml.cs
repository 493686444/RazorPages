using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;

namespace RazorPages.Pages
{
    public class MyMessageModel : PageModel
    {
        [BindProperty]
        public Message Message { get; set; }
        public List<Message> Messages { get; set; }
        
        SqlDbContext context = new SqlDbContext();
        public void OnGet()
        {
            Messages=context.Messages.Where(m => m.Author == 1).ToList();
        }
        public void OnPost()
        {

        }

    }
}
