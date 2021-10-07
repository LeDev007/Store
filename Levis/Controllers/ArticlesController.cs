using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Levis;
using Microsoft.AspNet.Identity;

namespace Levis.Controllers
{
    public class ArticlesController : Controller
    {
        private shopEntities2 db = new shopEntities2();

        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Article.ToList());
        }

        public ActionResult AddCart(int ArticleId)
        {
            var article = db.Article.Find(ArticleId);

            if (article != null)
            {
                Cart1 cart = new Cart1();


                cart.Article_id = Article.Id;
                cart.User_Id = User.Identity.GetUserId();
                cart.Article_name = article.Name;
                cart.Article_price = article.price;
                cart.Article_Qty = 1;
                cart.Article_imagePath = article.imagePath;

                db.Cart1Set.Add(cart);
                db.SaveChanges();
            }

            return Redirect("/");
        }


        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,description,price,ImagePath")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Article.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }


        public String[] AddCart(int ArticleId)
        {
            var article = db.Article.Find(ArticleId);

            if (article != null)
            {
                Cart1 cart = new Cart1();


                cart.Article_id = ArticleId;
                cart.User_Id = User.Identity.GetUserId();
                cart.Article_name = article.Name;
                cart.Article_price = article.price;
                cart.Article_Qty = 1;
                cart.Article_imagePath = article.ImagePath;

                db.Cart1Set.Add(cart);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    String[] table1 = new string[20];
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            int j = 0;
                            table1[j] = "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }

            return table1[];

        }


        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,description,price,ImagePath")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Article.Find(id);
            db.Article.Remove(article);
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
