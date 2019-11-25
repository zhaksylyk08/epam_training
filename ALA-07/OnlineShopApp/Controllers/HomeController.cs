using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp1.OnlineShop;


namespace ConsoleApp1.Controllers
{
    public class HomeController : Controller
    {
        private OnlineShopContext _onlineShopContext;
        public HomeController(Context onlineShopContext)
        {
            _onlineShopContext = onlineShopContext;
        }

        public IActionResult Index()
        {
            var products = _Context.Product.ToList();

            return View(products);
        }

        public IActionResult Orders()
        {
            var orders = _onlineShopContext.Orders.ToList();

            return View(orders);
        }

        public IActionResult Sellers()
        {
            var sellers = _onlineShopContext.Sellers.ToList();
            return View(sellers);
        }

        public IActionResult AddSeller()
        {
            var buyers = _onlineShopContext.Customers.Take(2).ToList();
            var seller = new Seller()
            {
                FirstName = "Seller" + DateTime.Now.Minute,
            };

            seller.BuyerSellers = buyers.Select(buyer => new BuyerSeller()
            {
                Seller = seller,
                Buyer = buyer
            }).ToList();


            _onlineShopContext.Sellers.Add(seller);
            _onlineShopContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult AddBuyer()
        {
            var sellers = _onlineShopContext.Sellers
                .OrderBy(x => x.BuyerSellers.Count)
                .Take(3).ToList();
            var customer = new Customer()
            {
                FirstName = "Buyer" + DateTime.Now.Minute,
            };

            customer.BuyerSellers = sellers.Select(seller => new BuyerSeller()
            {
                Seller = seller,
                Customer = customer
            }).ToList();


            _onlineShopContext.Customers.Add(customer);
            _onlineShopContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult AddProduct()
        {
            var product = new Product()
            {
                ProductName = "Smile" + DateTime.Now.Minute,
                Price = DateTime.Now.Second
            };

            _onlineShopContext.Product.Add(product);
            _onlineShopContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult AddOrder()
        {
            var products = _onlineShopContext.Product
                .Where(x => x.Order == null)
                .OrderByDescending(x => x.Price)
                .Take(2)
                .ToList();

            var order = new Order()
            {
                DateTime = DateTime.Now,
                Products = products
            };

            _onlineShopContext.Orders.Add(order);
            _onlineShopContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
