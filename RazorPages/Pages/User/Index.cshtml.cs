using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.User
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public void OnGet()
        {
            Id = Convert.ToInt32(Request.Query["Id"][0]);
            Name = "HJB";
            Level = 99;
        }
    }
}
