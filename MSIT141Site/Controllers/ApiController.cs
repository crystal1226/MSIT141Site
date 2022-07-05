using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSIT141Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ApiController(DemoContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment; //注入環境資訊取得伺服器上的實際路徑
        }

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

        public IActionResult Register(Member member, IFormFile file)
        {          
            //取得專案資料夾下wwwroot的實際路徑
            string path = Path.Combine(_hostEnvironment.WebRootPath, "uploads", file.FileName); //Combine--結合路徑
            using (var fileStream = new FileStream(path, FileMode.Create))  //using--for 自動關閉fileStream連接
            {
                file.CopyTo(fileStream);    //存入資料夾
            }
            //將img寫入資料庫
            byte[] imgByte = null;
            using(var memoryStream=new MemoryStream())
            {
                file.CopyTo(memoryStream);
                imgByte=memoryStream.ToArray();
            }
            member.FileData = imgByte;
            member.FileName = file.FileName;
            _context.Members.Add(member);
            _context.SaveChanges();

            string info = $"{file.FileName} - {file.ContentType} - {file.Length}";
            return Content(info, "text/plain", Encoding.UTF8);
        }

        //讀取城市
        public IActionResult City()
        {
            var city = _context.Addresses.Select(c => c.City).Distinct();
            return Json(city);  //Json()回傳JSON字串                
        }
        //根據讀出的城市讀取行政區
        public IActionResult District(string city)
        {
            var district = _context.Addresses.Where(c=>c.City==city).Select(d=>d.SiteId).Distinct();
            return Json(district);
        }
        //根據讀出的行政區讀取路名
        public IActionResult Road(string district)
        {
            var road = _context.Addresses.Where(d=>d.SiteId == district).Select(r=>r.Road).Distinct();
            return Json(road);
        }
        public IActionResult GetImageBytes(int id=1)
        {
            Member member = _context.Members.Find(id);
            byte[] img = member.FileData;
            return File(img, "image/jpeg");
        }

        public IActionResult Members()
        {
            return Json(_context.Members);            
        }
    }
}
