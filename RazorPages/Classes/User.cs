using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string password { set; get; }
        public bool Gender { set; get; }  
    }
}
