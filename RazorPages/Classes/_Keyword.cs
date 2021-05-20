using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class _Keyword : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            IList<Keyword> keywords = new List<Keyword>()
            {
                new Keyword { Id=1,Name="C#"},
                new Keyword { Id = 2, Name = ".NET" },
                new Keyword { Id=3,Name="Python"},
                new Keyword { Id=3,Name="操作系统"},
                new Keyword { Id=3,Name="HTML"}
            };
            return View("/Pages/Shared/Components/_Keyword.cshtml", keywords);//要么像视频那么写，要么这个文件url必须写写么长
        }
    }
}
