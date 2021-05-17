using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class Message
    {
        public int Id { set; get; }
        public DateTime DateTime { set; get; } = DateTime.Now;
        public string Type { set; get; }
        public string Content { set; get; }
        public int Author { set; get; }

        [NotMapped]
        public bool Selected { set; get; }


    }
}
