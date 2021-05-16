using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class User
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "用户名不可空")]
        public string Name { set; get; }

        [Required(ErrorMessage = "请输入密码")]
        public string password { set; get; }
        public bool Gender { set; get; }  
    }
}
