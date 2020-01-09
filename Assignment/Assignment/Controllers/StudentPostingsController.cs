using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class StudentPostingsController : Controller
    {
        private DataBContainer db = new DataBContainer();

        // GET: StudentPostings
        public ActionResult Index()
        {
            var studentPostings = db.StudentPostings.Include(s => s.UserDetailprop).Include(s => s.Competitionprop);
            return View(studentPostings.ToList());
        }

        // GET: StudentPostings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPosting studentPosting = db.StudentPostings.Find(id);
            if (studentPosting == null)
            {
                return HttpNotFound();
            }
            return View(studentPosting);
        }

        // GET: StudentPostings/Create
        public ActionResult Create()
        {
            ViewBag.UserDetailsId = new SelectList(db.UserDetails, "Id", "Name");
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Name");
            return View();
        }

        // POST: StudentPostings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks,Rating,compName,awardWin,noofAwards,Image,UserDetailsId,CompetitionId")] StudentPosting studentPosting)
        {
            if (ModelState.IsValid)
            {
                db.StudentPostings.Add(studentPosting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserDetailsId = new SelectList(db.UserDetails, "Id", "Name", studentPosting.UserDetailsId);
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Name", studentPosting.CompetitionId);
            return View(studentPosting);
        }

        // GET: StudentPostings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPosting studentPosting = db.StudentPostings.Find(id);
            if (studentPosting == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserDetailsId = new SelectList(db.UserDetails, "Id", "Name", studentPosting.UserDetailsId);
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Name", studentPosting.CompetitionId);
            return View(studentPosting);
        }

        // POST: StudentPostings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks,Rating,compName,awardWin,noofAwards,Image,UserDetailsId,CompetitionId")] StudentPosting studentPosting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentPosting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserDetailsId = new SelectList(db.UserDetails, "Id", "Name", studentPosting.UserDetailsId);
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Name", studentPosting.CompetitionId);
            return View(studentPosting);
        }

        // GET: StudentPostings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPosting studentPosting = db.StudentPostings.Find(id);
            if (studentPosting == null)
            {
                return HttpNotFound();
            }
            return View(studentPosting);
        }

        // POST: StudentPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentPosting studentPosting = db.StudentPostings.Find(id);
            db.StudentPostings.Remove(studentPosting);
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
