using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolProject.Core;
using SchoolProject.Infrastructure;

namespace SchoolProjectInMVC.Controllers
{
    public class StudentsController : Controller
    {
        private GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        private GenericRepository<Student> studentRepo;
        public StudentsController() {
            studentRepo = _unitOfWork.GetInstance<Student>();
        }
        // GET: Students
        public ActionResult Index()
        {
            //return View(db.Students.ToList());
            return View(studentRepo.GetAllRecords());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = studentRepo.GetFirstOrDefault(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,DOB")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Add(student);
                _unitOfWork.SaveChanges();
                //db.Students.Add(student);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = studentRepo.GetFirstOrDefault(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,DOB")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Update(student);
                _unitOfWork.SaveChanges();
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = studentRepo.GetFirstOrDefault(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Student student = db.Students.Find(id);
            //db.Students.Remove(student);
            //db.SaveChanges();
            Student student = studentRepo.GetFirstOrDefault(id);
            studentRepo.Delete(student);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
