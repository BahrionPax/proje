using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okul.Models;

namespace Okul.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OkulDb_1Context())
            {
                var lst = ctx.Ogrenciler.ToList();
                return View(lst);
            }
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OkulDb_1Context())
                {
                    ctx.Ogrenciler.Add(ogr);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditStudent(int id)
        {
            using (var ctx = new OkulDb_1Context())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                return View(ogr);
            }
        }

        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OkulDb_1Context())
                {
                    ctx.Entry(ogr).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new OkulDb_1Context())
            {
                ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

