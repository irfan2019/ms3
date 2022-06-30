using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using application_query.Models;

namespace application_query.Controllers
{
    public class course_tableController : Controller
    {
        private application_databaseEntities db = new application_databaseEntities();

        // GET: course_table
        public ActionResult Index()
        {
            return View(db.course_table.ToList());
        }

        // GET: course_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_table course_table = db.course_table.Find(id);
            if (course_table == null)
            {
                return HttpNotFound();
            }
            return View(course_table);
        }

        // GET: course_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: course_table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,age,email_id,profession,marks_12th,ug_degree,address,mobile_no,courses")] course_table course_table)
        {
            if (ModelState.IsValid)
            {
                db.course_table.Add(course_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course_table);
        }

        // GET: course_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_table course_table = db.course_table.Find(id);
            if (course_table == null)
            {
                return HttpNotFound();
            }
            return View(course_table);
        }

        // POST: course_table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,age,email_id,profession,marks_12th,ug_degree,address,mobile_no,courses")] course_table course_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course_table);
        }

        // GET: course_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_table course_table = db.course_table.Find(id);
            if (course_table == null)
            {
                return HttpNotFound();
            }
            return View(course_table);
        }

        // POST: course_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            course_table course_table = db.course_table.Find(id);
            db.course_table.Remove(course_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
