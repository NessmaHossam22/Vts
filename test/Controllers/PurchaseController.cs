using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Schema;
using test.Models;
using YourProjectName.Extensions;

namespace test.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly applictioncontext _context;

        public PurchaseController(applictioncontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Item.Include(i => i.mainitem).ToList();
            return View(items);
        }

       
       

            // عرض السلة
            public IActionResult Cart()
            {
                var cart = HttpContext.Session.GetObjectFromJson<CartItem>("Cart") ?? new CartItem();
                return View(cart);
            }

        // عرض السلة
        public IActionResult Checkout(CartItem carr)
        {
            var cart = HttpContext.Session.GetObjectFromJson<CartItem>("Cart") ?? new CartItem();
            
            if (cart != null)
            {
                cart.DicCount = carr.DicCount;
                cart.Total = cart.carts.Sum(x => x.Price * x.Quantity);
                cart.TotalPay = cart.Total -(cart.Total* (cart.DicCount/100));
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
           
            return View(cart);
        }

        // إضافة منتج إلى السلة
        public IActionResult AddToCart(int itemId,int quantity)
            {
                var item = _context.Item.FirstOrDefault(i => i.Id == itemId);

                if (item != null)
                {
                    var cart = HttpContext.Session.GetObjectFromJson<CartItem>("Cart") ?? new CartItem();

                    var cartItem = cart.carts.FirstOrDefault(c => c.ItemId == itemId);
                    if (cartItem != null)
                    {
                        cartItem.Quantity++;
                    }
                    else
                    {
                        cart.carts.Add(new cart { ItemId = itemId, ItemName = item.Name, Price = item.price, Quantity = quantity });
                    }

                    HttpContext.Session.SetObjectAsJson("Cart", cart);
                }

                return RedirectToAction("Cart");
            }

            // تحديث السلة (تعديل الكمية أو حذف العنصر)
            [HttpPost]
            public IActionResult UpdateCart(Dictionary<int, int> quantities, int? remove)
            {
                var cart = HttpContext.Session.GetObjectFromJson<CartItem>("Cart") ?? new CartItem();

                // حذف العنصر
                if (remove.HasValue)
                {
                    var itemToRemove = cart.carts.FirstOrDefault(c => c.ItemId == remove.Value);
                    if (itemToRemove != null)
                    {
                        cart.carts.Remove(itemToRemove);
                    }
                }

                // تحديث الكميات
                foreach (var cartItem in cart.carts)
                {
                    if (quantities.ContainsKey(cartItem.ItemId))
                    {
                        cartItem.Quantity = quantities[cartItem.ItemId];
                    }
                }

                HttpContext.Session.SetObjectAsJson("Cart", cart);

                return RedirectToAction("Cart");
            }

            // إتمام عملية الشراء
            public IActionResult CompleteCheckout()
            {
            int UserId= HttpContext.Session.GetInt32("UserId") ?? 0;
            if (UserId==0)
            {
                return RedirectToAction("Login", "Auth");
            }
            var cart = HttpContext.Session.GetObjectFromJson<CartItem>("Cart") ?? new CartItem();
            int x = cart.carts.Count 
;
                if (!cart.carts.Any())
                {
                    ViewBag.Message = "Your cart is empty!";
                    return View("Cart", cart);
                }
            invoice obj=new invoice();
            obj.total = cart.Total;
            obj.diCount = cart.DicCount;
            obj.totalpay = cart.TotalPay;


            obj.UserId = UserId;
            _context.invoice.Add(obj);
            _context.SaveChanges();

            foreach (var cartItem in cart.carts)
            {
                var item = _context.Item.FirstOrDefault(i => i.Id == cartItem.ItemId);
                if (item == null || item.quanity < cartItem.Quantity)
                {
                    ViewBag.Error = $"Insufficient quantity for item: {cartItem.ItemName}";
                    return View("Cart", cart);
                }
                else {
                    item.quanity -= cartItem.Quantity;
                    _context.SaveChanges();
                    invoiceDetlies invoiceDetlies = new invoiceDetlies();
                invoiceDetlies.invoiceId = obj.Id;
                invoiceDetlies.price = cartItem.Price;
                invoiceDetlies.quantity = cartItem.Quantity;
                    invoiceDetlies.itemname = item.Name;
                    invoiceDetlies.total = cartItem.Price* cartItem.Quantity;
                    invoiceDetlies.itemId = cartItem.ItemId;



                    _context.invoiceDetlies.Add(invoiceDetlies);
                _context.SaveChanges();
            }

                }

               

                HttpContext.Session.Remove("Cart");
                ViewBag.Message = "Purchase completed successfully!";
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult getUserOrder()
        {
            int UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (UserId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            List<invoice> invoices = _context.invoice.Where(x=>x.UserId==UserId).Include(x=>x.User).Include(x=>x.InvoiceDetlies).ToList();
            return View(invoices);

        }
        

      
    }

}
