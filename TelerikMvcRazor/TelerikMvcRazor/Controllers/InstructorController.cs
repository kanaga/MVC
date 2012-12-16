using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCMU.Models;
using RCMU_Domain.Entities;
using RCMU_Domain.DBContext;

namespace RCMU.Controllers
{ 
    public class InstructorController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //
        // GET: /Instructor/

       

        public ActionResult Index(Int32? id,Int32? courseId)
        {
            var Model = new IndexInstructorData();
            Model.Instructors = db.Instructors
                .Include(p => p.OfficeAssignment)
                .Include(p => p.Courses.Select(c => c.Department)).OrderBy(p=>p.LastName);

            if(id!=null)
            {
                ViewBag.InstructorID = id.Value;
                Model.Courses = Model.Instructors.Where(i => i.InstructorID == id.Value).Single().Courses;
            }
            if(courseId!=null)
            {
                ViewBag.CourseID = courseId.Value;
                var selectedcourse = Model.Courses.Where(x => x.CourseID == courseId).Single();
                db.Entry(selectedcourse).Collection(x => x.Enrollments).Load();
                foreach (Enrollment enrollment in selectedcourse.Enrollments)
                {
                    db.Entry(enrollment).Reference(x => x.Student).Load();
                }

                Model.Enrollments = selectedcourse.Enrollments;


            }
            return View(Model);

        }

        //
        // GET: /Instructor/Details/5

        public ViewResult Details(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            return View(instructor);
        }

        //
        // GET: /Instructor/Create

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.OfficeAssignments, "InstructorID", "Location");
            return View();
        } 

        //
        // POST: /Instructor/Create

        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.InstructorID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.InstructorID);
            return View(instructor);
        }
        
        //
        // GET: /Instructor/Edit/5
 
        public ActionResult Edit(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            ViewBag.InstructorID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.InstructorID);
            return View(instructor);
        }

        //
        // POST: /Instructor/Edit/5

        [HttpPost]
        public ActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.InstructorID);
            return View(instructor);
        }

        //
        // GET: /Instructor/Delete/5
 
        public ActionResult Delete(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            return View(instructor);
        }

        //
        // POST: /Instructor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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