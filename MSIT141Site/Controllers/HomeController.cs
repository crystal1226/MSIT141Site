using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSIT141Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;

        public HomeController(ILogger<HomeController> logger,DemoContext context)
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
        public IActionResult Homework2()
        {
            return View();
        }
        public IActionResult CheckAccount(Users user)   //HW2--帳號驗證
        {            
            var members = (from m in _context.Members
                                select m).ToList();           
            foreach(var mem in members)
            {
                if(mem.Name==user.name)
                    return Content("此帳號已被使用");
            }
            return Content("此帳號可以使用");        
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
