using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCMU_Domain.Entities;
using RCMU_Domain.DBContext;

namespace RCMU.Controllers
{ 
    public class CourseController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //
        // GET: /Courses/

        public ViewResult Index()
        {
            var courses = db.Courses.Include(c => c.Department);
            return View(courses.ToList());
        }

        //
        // GET: /Courses/Details/5

        public ViewResult Details(int id)
        {
            Course course = db.Courses.Find(id);
            return View(course);
        }

        //
        // GET: /Courses/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
            return View();
        } 

        //
        // POST: /Courses/Create

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }
        
        //
        // GET: /Courses/Edit/5
 
        public ActionResult Edit(int id)
        {
            Course course = db.Courses.Find(id);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        //
        // POST: /Courses/Edit/5

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        //
        // GET: /Courses/Delete/5
 
        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            return View(course);
        }

        //
        // POST: /Courses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}