using Microsoft.AspNetCore.Mvc;
using MSIT141Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(Users user)
        {
            //Thread.Sleep(5000); 
            if (String.IsNullOrEmpty(user.name))
            {
                user.name = "Ajax";
            }
            //return Content("<h2>Ajax,你好!</h2>", "text/html",System.Text.Encoding.UTF8);
            return Content($"{user.name}你好, 你的年紀是{user.age}, Email為{user.email}", "text/html", System.Text.Encoding.UTF8);
        }

    }
}
