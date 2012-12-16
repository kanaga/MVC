using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCMU_Domain.Entities;
using RCMU_Domain.DBContext;
using Telerik.Web.Mvc;
using RCMU;

namespace RCMU.Controllers
{ 
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();
        //
        // GET: /Student/

        public ViewResult Index(string sortorder, string Searchstring)
        {
            ViewBag.Sortparm = String.IsNullOrEmpty(sortorder) ? "Name Desc" : "";
            ViewBag.Dateparm = sortorder == "Date" ? "Date Desc" : "Date";
            var students = from s in db.Students
                           select s;

            if(!String.IsNullOrEmpty(Searchstring))
            {
                students =
                    students.Where(
                        p =>
                        p.FirstMidName.ToLower().Contains(Searchstring.ToLower()) ||
                        (p.LastName.ToLower().Contains(Searchstring.ToLower())));
            }

            switch(sortorder)
            {
                
                case("Name Desc"):
                    students = students.OrderByDescending(p => p.LastName);
                    break;

                case("Date Desc"):
                    students = students.OrderByDescending(p => p.EnrollmentDate);
                    break;
                case("Date"):
                    students = students.OrderBy(p => p.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(p => p.LastName);
                    break;
            }
            return View(students.ToList());
        }

        //
        // GET: /Student/Details/5

        public ViewResult Details(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        //
        // GET: /Student/Create
       
        public ActionResult Create()
        {
            
            return View();
        } 

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");  
                }   
            }
            catch (DataException)
            {
                    
                ModelState.AddModelError("","Unable to save changes");
            }
          

            return View(student);
        }
        
        //
        // GET: /Student/Edit/5
 
        public ActionResult Edit(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5
 
        public ActionResult Delete(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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