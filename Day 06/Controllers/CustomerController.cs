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
    public class CustomerController : Controller
    {
        StoreContext context = new StoreContext();

        public IActionResult Index()
        {
            return View(context.Customers.ToList());
        }

        [Route("/Customer/{id:int}")]
        public IActionResult Details(int id)
        {
            return View(context.Customers.Find(id));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            return View(context.Customers.Find(id));
        }


        [HttpPost]
        public IActionResult Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedCustomer = context.Customers.Find(customer.ID) ?? throw new Exception();
                    updatedCustomer.PhoneNum = customer.PhoneNum;
                    updatedCustomer.Name = customer.Name;
                    updatedCustomer.Email = customer.Email;
                    updatedCustomer.Gender = customer.Gender;
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            return View(customer);
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
