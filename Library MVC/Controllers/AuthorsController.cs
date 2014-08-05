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
    public class AuthorsController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Authors/

        public ViewResult Index()
        {
            return View(context.Authors.ToList());
        }

        //
        // GET: /Authors/Details/5

        public ViewResult Details(int id)
        {
            Author author = context.Authors.Single(x => x.AuthorID == id);
            return View(author);
        }

        //
        // GET: /Authors/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Authors/Create

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                context.Authors.Add(author);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(author);
        }
        
        //
        // GET: /Authors/Edit/5
 
        public ActionResult Edit(int id)
        {
            Author author = context.Authors.Single(x => x.AuthorID == id);
            return View(author);
        }

        //
        // POST: /Authors/Edit/5

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                context.Entry(author).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        //
        // GET: /Authors/Delete/5
 
        public ActionResult Delete(int id)
        {
            Author author = context.Authors.Single(x => x.AuthorID == id);
            return View(author);
        }

        //
        // POST: /Authors/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = context.Authors.Single(x => x.AuthorID == id);
            context.Authors.Remove(author);
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