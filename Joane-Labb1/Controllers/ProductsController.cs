using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Joane_Labb1.Models;

namespace Joane_Labb1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult DisplayProducts()
        {
            List<ProductModel> listproducts = new List<ProductModel>();
            ProductModel products = new ProductModel();

            products.ProductName= "BMW 328i";
            products.Description = "BMW F31 328i Touring";
            products.Price = 220000;
            listproducts.Add(products);

            products.ProductName = "BMW 520d";
            products.Description = "BMW F11 520d Touring";
            products.Price = 250000;
            listproducts.Add(products);

            return View(listproducts);
        }
    }
}