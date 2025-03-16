using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day_06.Models;

namespace Day_06.Controllers
{
    public class OrderController : Controller
    {
        StoreContext context;

        public OrderController(StoreContext context) => this.context = context;

        public IActionResult Index()
        {
            ViewBag.Customers = new SelectList(context.Customers.ToList(),"ID","Email");
            return View(context.Orders.Include(o => o.Customer).ToList());
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            ViewBag.Customers = new SelectList(context.Customers.ToList(), "ID", "Email",id);
            return View(context.Orders.Include(o => o.Customer).Where(o => o.CustID == id).ToList());
        }

        [Route("/Order/{id:int}")]
        public IActionResult Details(int id)
        {
            return View(context.Orders.Include(o => o.Customer).SingleOrDefault(m => m.ID == id));
        }

        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(context.Customers, "ID", "Email");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Add(order);
                context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = new SelectList(context.Customers, "ID", "Email");
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Customers = new SelectList(context.Customers, "ID", "Email");
            return View(context.Orders.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedOrder = context.Orders.Find(order.ID) ?? throw new Exception("");
                    updatedOrder.TotalPrice = order.TotalPrice;
                    updatedOrder.CustID = order.CustID; 
                    updatedOrder.Date = order.Date;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Customers = new SelectList(context.Customers, "ID", "Email");
            return View(order);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = context.Orders.Find(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
