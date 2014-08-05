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
    public class LiteratureTypesController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /LiteratureTypes/

        public ViewResult Index()
        {
            return View(context.LiteratureTypes.ToList());
        }

        //
        // GET: /LiteratureTypes/Details/5

        public ViewResult Details(int id)
        {
            LiteratureType literaturetype = context.LiteratureTypes.Single(x => x.TypeID == id);
            return View(literaturetype);
        }

        //
        // GET: /LiteratureTypes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /LiteratureTypes/Create

        [HttpPost]
        public ActionResult Create(LiteratureType literaturetype)
        {
            if (ModelState.IsValid)
            {
                context.LiteratureTypes.Add(literaturetype);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(literaturetype);
        }
        
        //
        // GET: /LiteratureTypes/Edit/5
 
        public ActionResult Edit(int id)
        {
            LiteratureType literaturetype = context.LiteratureTypes.Single(x => x.TypeID == id);
            return View(literaturetype);
        }

        //
        // POST: /LiteratureTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(LiteratureType literaturetype)
        {
            if (ModelState.IsValid)
            {
                context.Entry(literaturetype).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(literaturetype);
        }

        //
        // GET: /LiteratureTypes/Delete/5
 
        public ActionResult Delete(int id)
        {
            LiteratureType literaturetype = context.LiteratureTypes.Single(x => x.TypeID == id);
            return View(literaturetype);
        }

        //
        // POST: /LiteratureTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LiteratureType literaturetype = context.LiteratureTypes.Single(x => x.TypeID == id);
            context.LiteratureTypes.Remove(literaturetype);
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