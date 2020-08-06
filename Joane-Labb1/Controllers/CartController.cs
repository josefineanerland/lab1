using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Joane_Labb1.Models;
using Microsoft.AspNetCore.Http;
using Joane_Labb1.Helpers;
using Joane_Labb1.Data;
using Newtonsoft.Json;



namespace Joane_Labb1.Controllers
{

    [Route("cart")]
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        public IActionResult Index()
        {
            if (ViewBag.cart != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            }
            else
            {
                ViewBag.Message = "Your cart is empty";
            }

            return View();
        }

        [Route("AddToCart/{id}")]
        public IActionResult AddToCart(Guid id)
        {
            ProductModel productModel = new ProductModel();
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = _context.ProductModel.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = _context.ProductModel.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("RemoveFromCart/{id}")]
        public IActionResult RemoveFromCart(Guid id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(Guid id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult ProceedToCheckout()
        {
            if (User.Identity.Name != null)
            {
                return View("Checkout");
            }
            else
            {
                return Redirect("~/Identity/Account/Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder([Bind("Firstname,Lastname,Adress,PostalCode,City,Orderdate,Products")] OrderModel orderModel)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (ModelState.IsValid)
            {
                //if(!(_context.OrderModel.Any()))
                //{
                //    orderModel.OrderId = 1;
                //}
                
                orderModel.UserId = Guid.Parse(_context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id);
                orderModel.Orderdate = DateTime.Now;
                orderModel.Products = JsonConvert.SerializeObject(cart);   
                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //return View(orderModel);
            return RedirectToAction("Index", "Home");
        }
    }
}