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
        public List<Message> Messages { get; set; }
        private SqlDbContext context = new SqlDbContext();
        public void OnGet()
        {
            Messages = context.Messages.Where(m => m.Author == 1).ToList();//ȡ��������idΪ1����Ϣ
        }
        public IActionResult OnPost()
        {            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (var item in Messages)
            {
                if (item.Selected)
                {
                    context.Messages.Remove(item);
                }
            }
            context.SaveChanges();
            return RedirectToPage();   //�ض������page
        }
    }
}
