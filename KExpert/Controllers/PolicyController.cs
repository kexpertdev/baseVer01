using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer;

namespace KExpert.Controllers
{
    public class PolicyController : Controller
    {
        private KExpertContext db = new KExpertContext();

        // GET: /Policy/
        public ActionResult Index()
        {
            return View(db.Policy.ToList());
        }

        // GET: /Policy/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = db.Policy.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: /Policy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Policy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PolicyNumber,InsuranceCompany,InsurancePolicyNumber,PolicyStart,PolicyEnd,CancelledAt,CancelledFrom,IsLimitedTerm,CreatedDate,LastModifiedDate,LastModifiedReason")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policy.Add(policy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policy);
        }

        // GET: /Policy/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = db.Policy.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: /Policy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PolicyNumber,InsuranceCompany,InsurancePolicyNumber,PolicyStart,PolicyEnd,CancelledAt,CancelledFrom,IsLimitedTerm,CreatedDate,LastModifiedDate,LastModifiedReason")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        // GET: /Policy/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = db.Policy.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: /Policy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Policy policy = db.Policy.Find(id);
            db.Policy.Remove(policy);
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
