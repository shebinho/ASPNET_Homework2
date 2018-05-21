using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class PictureController : Controller
    {
        public ActionResult Index()
        {
            SedcDatabase database = new SedcDatabase();
            List<Picture> pictures = database.Pictures
                .ToList();
            return View(pictures);
        }

        public ActionResult Create()
        {

            //string path =  Directory.GetCurrentDirectory();
            return View("~/Views/Picture/CreateWithHelpers.cshtml");
        }

        [HttpPost]
        public ActionResult Create(Picture picture)
        {
            if (ModelState.IsValid)
            {
                var db = new SedcDatabase();
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Picture/CreateWithHelpers.cshtml", picture);
        }

        public ActionResult Edit(int id)
        {
            
            
                var db = new SedcDatabase();
                var picture = db.Pictures.FirstOrDefault(x => x.Id == id);
                db.SaveChanges();

                return View(picture);
        }

        [HttpPost]
        public ActionResult Edit(Picture img, int id)
        {

            if (ModelState.IsValid)
            {
                var db = new SedcDatabase();
                var picture = db.Pictures.FirstOrDefault(x => x.Id == id);

                picture.Id = img.Id;
                picture.DisplayName = img.DisplayName;
                picture.Url = img.Url;
                picture.PhotographerEmail = img.PhotographerEmail;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit");
        }

        public ActionResult Details (int id)
        {
            var db = new SedcDatabase();
            var picture = db.Pictures.FirstOrDefault(x => x.Id == id);
            db.SaveChanges();

            return View(picture);
        }

        public ActionResult Delete(int id)
        {
            
            
            var db = new SedcDatabase();
            var picture = db.Pictures.FirstOrDefault(x => x.Id == id);
            db.SaveChanges();
            return View(picture);
            
        }

        [HttpPost]
        public ActionResult Delete(int id , Picture img)
        {
            
            
                var db = new SedcDatabase();
                var picture = db.Pictures.FirstOrDefault(x => x.Id == id);
                db.Pictures.Remove(picture);
                db.SaveChanges();

                return RedirectToAction("Index");
            
            


        }
        
    }
}