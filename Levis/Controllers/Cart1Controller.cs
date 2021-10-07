using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Levis;

namespace Levis.Controllers
{
    public class Cart1Controller : Controller
    {
        private shopEntities2 db = new shopEntities2();

        // GET: Cart1
        public ActionResult Index()
        {
            return View(db.Cart1Set.ToList());
        }

        // GET: Cart1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart1 cart1 = db.Cart1Set.Find(id);
            if (cart1 == null)
            {
                return HttpNotFound();
            }
            return View(cart1);
        }

        // GET: Cart1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Article_id,Article_name,Article_price,Article_Qty,Article_imagePath,User_Id")] Cart1 cart1)
        {
            if (ModelState.IsValid)
            {
                db.Cart1Set.Add(cart1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart1);
        }

        // GET: Cart1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart1 cart1 = db.Cart1Set.Find(id);
            if (cart1 == null)
            {
                return HttpNotFound();
            }
            return View(cart1);
        }

        // POST: Cart1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Article_id,Article_name,Article_price,Article_Qty,Article_imagePath,User_Id")] Cart1 cart1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart1);
        }

        // GET: Cart1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart1 cart1 = db.Cart1Set.Find(id);
            if (cart1 == null)
            {
                return HttpNotFound();
            }
            return View(cart1);
        }

        // POST: Cart1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cart1 cart1 = db.Cart1Set.Find(id);
            db.Cart1Set.Remove(cart1);
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
