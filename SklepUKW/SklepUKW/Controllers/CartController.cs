using SklepUKW.DAL;
using SklepUKW.Infrastructure;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    public class CartController : Controller
    {
        CartManager cartManager;
        FilmsContext db;
        ISessionManager session;

        public CartController()
        {
            db = new FilmsContext();
            session = new SessionManager();
            cartManager = new CartManager(db, session);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = cartManager.GetItems();
            var totalValue = cartManager.GetCartValue();

            CartViewModel cvm = new CartViewModel()
            {
                CartItems = cart,
                TotalPrice = totalValue
            };

            return View(cvm);
        }

        public ActionResult AddToCart(int id)
        {
            cartManager.AddToCart(id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            ItemRemoveViewModel irvm = new ItemRemoveViewModel()
            {
                itemQuantity = cartManager.RemoveFromCart(id),
                cartValue = cartManager.GetCartValue(),
                itemId = id
            };

            return Json(irvm);
        }
    }
}