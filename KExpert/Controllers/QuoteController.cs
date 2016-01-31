using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KE.DataLayer;
using KE.Entities.Models;
using KE.BusinessLayer;

namespace KExpert.Controllers
{
    public class QuoteController : BaseController
    {
        //private KexpertDb db = new KexpertDb();

        public QuoteController(IPolicyService service) : base(service)
        {
        }

        // GET: Quote
        public ActionResult Index()
        {
            return View(Service.GetQuotes());
        }

        // GET: Quote/Details/5
        public ActionResult Details(long? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //QuoteDto quoteDto = db.QuoteDtoes.Find(id);
            //if (quoteDto == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(quoteDto);
            return View();
        }

        // GET: Quote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Guid,Broker_ID,Product_ID,PolicyType_ID,PolicyStartDate,PolicyNrOfMonthsValid,PolicyPaymentMethod_ID,VehicleType_ID,VehicleUsage_ID,IsLegalPerson,PostalCode,RequestUrl,Premium,PolicyEndDate,Created")] QuoteDto quoteDto)
        {
            //if (ModelState.IsValid)
            //{
            //    db.QuoteDtoes.Add(quoteDto);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(quoteDto);
            return View();
        }

        // GET: Quote/Edit/5
        public ActionResult Edit(long? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //QuoteDto quoteDto = db.QuoteDtoes.Find(id);
            //if (quoteDto == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(quoteDto);
            return View();
        }

        // POST: Quote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Guid,Broker_ID,Product_ID,PolicyType_ID,PolicyStartDate,PolicyNrOfMonthsValid,PolicyPaymentMethod_ID,VehicleType_ID,VehicleUsage_ID,IsLegalPerson,PostalCode,RequestUrl,Premium,PolicyEndDate,Created")] QuoteDto quoteDto)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(quoteDto).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(quoteDto);
            return View();
        }

        // GET: Quote/Delete/5
        public ActionResult Delete(long? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //QuoteDto quoteDto = db.QuoteDtoes.Find(id);
            //if (quoteDto == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(quoteDto);
            return View();
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //QuoteDto quoteDto = db.QuoteDtoes.Find(id);
            //db.QuoteDtoes.Remove(quoteDto);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}
