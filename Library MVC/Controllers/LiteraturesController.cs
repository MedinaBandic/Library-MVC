using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_MVC.Models;

namespace Library_MVC.Controllers
{   
    public class LiteraturesController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Literatures/

        public ViewResult Index()
        {
            return View(context.Literatures.Include(literature => literature.Author).Include(literature => literature.Publisher).ToList());
        }

        //
        // GET: /Literatures/Details/5

        public ViewResult Details(long id)
        {
            Literature literature = context.Literatures.Single(x => x.ISBN == id);
            return View(literature);
        }

        //
        // GET: /Literatures/Create

        public ActionResult Create()
        {
            ViewBag.PossibleAuthors = context.Authors;
            ViewBag.PossiblePublishers = context.Publishers;
            return View();
        } 

        //
        // POST: /Literatures/Create

        [HttpPost]
        public ActionResult Create(Literature literature)
        {
            if (ModelState.IsValid)
            {
                context.Literatures.Add(literature);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleAuthors = context.Authors;
            ViewBag.PossiblePublishers = context.Publishers;
            return View(literature);
        }
        
        //
        // GET: /Literatures/Edit/5
 
        public ActionResult Edit(long id)
        {
            Literature literature = context.Literatures.Single(x => x.ISBN == id);
            ViewBag.PossibleAuthors = context.Authors;
            ViewBag.PossiblePublishers = context.Publishers;
            return View(literature);
        }

        //
        // POST: /Literatures/Edit/5

        [HttpPost]
        public ActionResult Edit(Literature literature)
        {
            if (ModelState.IsValid)
            {
                context.Entry(literature).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleAuthors = context.Authors;
            ViewBag.PossiblePublishers = context.Publishers;
            return View(literature);
        }

        //
        // GET: /Literatures/Delete/5
 
        public ActionResult Delete(long id)
        {
            Literature literature = context.Literatures.Single(x => x.ISBN == id);
            return View(literature);
        }

        //
        // POST: /Literatures/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Literature literature = context.Literatures.Single(x => x.ISBN == id);
            context.Literatures.Remove(literature);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}