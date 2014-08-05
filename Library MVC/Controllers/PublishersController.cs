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
    public class PublishersController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Publishers/

        public ViewResult Index()
        {
            return View(context.Publishers.ToList());
        }

        //
        // GET: /Publishers/Details/5

        public ViewResult Details(int id)
        {
            Publisher publisher = context.Publishers.Single(x => x.PublisherID == id);
            return View(publisher);
        }

        //
        // GET: /Publishers/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Publishers/Create

        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                context.Publishers.Add(publisher);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(publisher);
        }
        
        //
        // GET: /Publishers/Edit/5
 
        public ActionResult Edit(int id)
        {
            Publisher publisher = context.Publishers.Single(x => x.PublisherID == id);
            return View(publisher);
        }

        //
        // POST: /Publishers/Edit/5

        [HttpPost]
        public ActionResult Edit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                context.Entry(publisher).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        //
        // GET: /Publishers/Delete/5
 
        public ActionResult Delete(int id)
        {
            Publisher publisher = context.Publishers.Single(x => x.PublisherID == id);
            return View(publisher);
        }

        //
        // POST: /Publishers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Publisher publisher = context.Publishers.Single(x => x.PublisherID == id);
            context.Publishers.Remove(publisher);
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