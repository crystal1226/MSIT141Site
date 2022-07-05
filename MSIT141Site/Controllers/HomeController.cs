using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSIT141Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;

        public HomeController(ILogger<HomeController> logger, DemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Homework1()
        {
            return View();
        }
        public IActionResult FirstAjax()
        {
            return View();
        }
        public IActionResult AjaxPost()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Register(Member member,IFormFile file)
        //{
        //    string info = $"{file.FileName} - {file.ContentType} - {file.Length}";
        //    return Content(info, "text/plain", Encoding.UTF8);            
        //}
        public IActionResult Homework2()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult CheckAccount(string name)   //HW2--帳號驗證
        {
            //var members = (from m in _context.Members
            //                    select m.Name).ToList();

            //if (members.Contains(user.name))
            //    return Content("此帳號已被使用");
            //return Content("此帳號可以使用"); 

            var existed = _context.Members.Any(m => m.Name == name);
            return Content(existed.ToString(), "text/plain");
        }
        public IActionResult Promise()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }
        public IActionResult Homework3()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
