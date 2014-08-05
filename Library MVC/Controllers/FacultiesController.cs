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
    public class FacultiesController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Faculties/

        public ViewResult Index()
        {
            return View(context.Faculties.ToList());
        }

        //
        // GET: /Faculties/Details/5

        public ViewResult Details(int id)
        {
            Faculty faculty = context.Faculties.Single(x => x.FacultyID == id);
            return View(faculty);
        }

        //
        // GET: /Faculties/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Faculties/Create

        [HttpPost]
        public ActionResult Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                context.Faculties.Add(faculty);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(faculty);
        }
        
        //
        // GET: /Faculties/Edit/5
 
        public ActionResult Edit(int id)
        {
            Faculty faculty = context.Faculties.Single(x => x.FacultyID == id);
            return View(faculty);
        }

        //
        // POST: /Faculties/Edit/5

        [HttpPost]
        public ActionResult Edit(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                context.Entry(faculty).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        //
        // GET: /Faculties/Delete/5
 
        public ActionResult Delete(int id)
        {
            Faculty faculty = context.Faculties.Single(x => x.FacultyID == id);
            return View(faculty);
        }

        //
        // POST: /Faculties/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = context.Faculties.Single(x => x.FacultyID == id);
            context.Faculties.Remove(faculty);
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