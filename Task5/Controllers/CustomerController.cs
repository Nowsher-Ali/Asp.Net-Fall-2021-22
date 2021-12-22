using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Task5.Models;

namespace Task5.Controllers
{
    public class CustomerController : Controller
    {
        public object Products { get; private set; }

        // GET: Customer
        [Authorize]
        public ActionResult Index()
        {
            var db = new EMSEntities2();
            var data = db.Products.ToList();
            return View(data);
        }

        public ActionResult AddToCart(int id)
        {
            var db = new EMSEntities2();
            var data = (from p in db.Products
                        where p.Id == id
                        select p).FirstOrDefault();
            if (Session["Cart"] == null)
            {
                List<Product> Products = new List<Product>();
                Products.Add(data);
                Content.Configuration.ProxyCreationEnabled = false;
                string json = new JavaScriptSerializer().Serialize(Products);
                Session["Cart"] = json;
            }
            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());
                d.Add(data);
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
        
        [Authorize]
        public ActionResult CheckOut()
        {
            int cid = Int32.Parse(User.Identity.Name);
            var db = new EMSEntities2();
            var Products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());

            Dictionary<int, int> hash = new Dictionary<int, int>();
            int pp = 0;

            foreach (var p in Products)
            {
                if (!hash.ContainsKey(p.Id))
                {
                    hash.Add(p.Id, 1);
                }
                else
                {
                    hash[p.Id] = hash[p.Id] + 1;
                }
                pp += p.Price;
            }


            Order o = new Order()
            {
                CustomerId = cid,
                status = "Ordered",
                price = pp 
            };
            db.Orders.Add(o);
            db.SaveChanges();
            foreach (var p in Products) {
                var x = new Orderdetail()
                {
                    OrderId = o.Id,
                    ProductId = p.Id,
                    Qty = hash[p.Id],
                    unitPrice = p.Price
                };
                db.Orderdetails.Add(x);
                db.SaveChanges();
            }


            Session.Remove("cart");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(string phone, string password)
        {
            var db = new EMSEntities2();
            var data = (from val in db.Customers
                        where val.Phone == phone && val.Password == password
                        select val).FirstOrDefault();
            if(data!=null)
            {
                string s = data.Id.ToString();
                FormsAuthentication.SetAuthCookie(s, true);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}