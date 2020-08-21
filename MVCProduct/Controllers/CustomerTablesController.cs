using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProduct;

namespace MVCProduct.Controllers
{
    public class CustomerTablesController : Controller
    {
        private AssignmentsEntities db = new AssignmentsEntities();

        // GET: CustomerTables
        public ActionResult Index()
        {
            var customerTables = db.CustomerTables.Include(c => c.ProductTable);
            return View(customerTables.ToList());
        }

        // GET: CustomerTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // GET: CustomerTables/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName");
            return View();
        }

        // POST: CustomerTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerName,ProductId")] CustomerTable customerTable)
        {
            if (ModelState.IsValid)
            {
                db.CustomerTables.Add(customerTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName", customerTable.ProductId);
            return View(customerTable);
        }

        // GET: CustomerTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName", customerTable.ProductId);
            return View(customerTable);
        }

        // POST: CustomerTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,ProductId")] CustomerTable customerTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName", customerTable.ProductId);
            return View(customerTable);
        }

        // GET: CustomerTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // POST: CustomerTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            db.CustomerTables.Remove(customerTable);
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
