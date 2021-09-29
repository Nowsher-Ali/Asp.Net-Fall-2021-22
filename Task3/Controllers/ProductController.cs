using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models.Entities;
using System.Data.SqlClient;
using Task2.Models;
using System.Web.Script.Serialization;

namespace Task2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product s, int id)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Edit(s, id);
                return RedirectToAction("Index");
            }
            return View(s);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Delete(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
     
            if (Session["Cart"]==null)
            {
                List<Product> Products = new List<Product>();
                Products.Add(p);
                string json = new JavaScriptSerializer().Serialize(Products);
                Session["Cart"] = json;
            }
            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());
                d.Add(p);
                string json = new JavaScriptSerializer().Serialize(d);
                Session["Cart"] = json;
            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewCart()
        {

            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());
                return View(d);
            }
        }
        public ActionResult CheckOut()
        {
            Database db = new Database();
            var Products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());
            db.Products.CheckOut(Products);
            Session["Cart"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult EmptyCart()
        {
            Session["Cart"] = null;
            return RedirectToAction("Index");
        }
    }
}