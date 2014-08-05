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
    public class DepartmentsController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Departments/

        public ViewResult Index()
        {
            return View(context.Departments.Include(department => department.Faculty).ToList());
        }

        //
        // GET: /Departments/Details/5

        public ViewResult Details(int id)
        {
            Department department = context.Departments.Single(x => x.DepartmentID == id);
            return View(department);
        }

        //
        // GET: /Departments/Create

        public ActionResult Create()
        {
            ViewBag.PossibleFaculties = context.Faculties;
            return View();
        } 

        //
        // POST: /Departments/Create

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleFaculties = context.Faculties;
            return View(department);
        }
        
        //
        // GET: /Departments/Edit/5
 
        public ActionResult Edit(int id)
        {
            Department department = context.Departments.Single(x => x.DepartmentID == id);
            ViewBag.PossibleFaculties = context.Faculties;
            return View(department);
        }

        //
        // POST: /Departments/Edit/5

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Entry(department).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleFaculties = context.Faculties;
            return View(department);
        }

        //
        // GET: /Departments/Delete/5
 
        public ActionResult Delete(int id)
        {
            Department department = context.Departments.Single(x => x.DepartmentID == id);
            return View(department);
        }

        //
        // POST: /Departments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = context.Departments.Single(x => x.DepartmentID == id);
            context.Departments.Remove(department);
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