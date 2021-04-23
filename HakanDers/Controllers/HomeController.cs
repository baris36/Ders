using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HakanDers.Models.Entity;

namespace HakanDers.Controllers
{
    public class HomeController : Controller
    {
        UserEntities db = new UserEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Users kisi)
        {

            db.Users.Add(kisi);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Düzenle(int id)
        {

            return View(db.Users.Find(id));

        }

        [HttpPost]
        public ActionResult Düzenle(Users kisi)
        {
            if (kisi!=null)
            {

            }

            var güncelle = db.Users.Find(kisi.UserId);
            if (güncelle!=null)
            {
                güncelle.UserId = kisi.UserId;
                güncelle.UserName = kisi.UserName;
                güncelle.UserSurname = kisi.UserSurname;
                db.SaveChanges();

                return RedirectToAction("Index");
            }            


            return View();

        }


        public ActionResult Sil(int? id)
        {
            if (id>0)
            {
                var sil = db.Users.Find(id);
                if (sil != null)
                {
                    db.Users.Remove(sil);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}