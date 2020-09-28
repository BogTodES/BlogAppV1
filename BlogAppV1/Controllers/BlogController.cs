using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult ShowBlog(int id)
        {
            return View();
        }

        public IActionResult ShowBlog(string title)
        {
            return View();
        }

        public IActionResult ShowBlogsOfUser(string username)
        {
            return View();
        }
    }
}
