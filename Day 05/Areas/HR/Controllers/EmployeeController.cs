using Day_05.Areas.HR.Models;
using Day_05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day_05.Areas.HR.Controllers
{
    [Area("HR")]
    public class EmployeeController : Controller
    {
        CompanyContext context = new();
        public ActionResult Index()
        {
            ViewBag.depts = new SelectList(context.Departments.ToList(), "ID", "Name");
            return View(context.Employees.Include(e => e.Department).ToList());
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            ViewBag.depts = new SelectList(context.Departments.ToList(), "ID", "Name",id);
            return View(context.Employees.Include(e => e.Department).Where(e => e.DeptID == id).ToList());
        }

        [Route("/Employee/{id:int}")]
        public ActionResult Details(int id)
        {
            return View(context.Employees.Include(e => e.Department).SingleOrDefault(e => e.ID == id));
        }

        public ActionResult Create()
        {
            ViewBag.depts = new SelectList(context.Departments.ToList(),"ID","Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.depts = new SelectList(context.Departments.ToList(), "ID", "Name");
                return View(emp);
            }
        }

        public ActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.ID == id);
            ViewBag.depts = new SelectList(context.Departments.ToList(), "ID", "Name");
            return emp == null ? RedirectToAction("Index") : View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                var updatedEmp = context.Employees.Find(emp.ID);

                if (updatedEmp == null) return RedirectToAction("Index");

                updatedEmp.PhoneNum = emp.PhoneNum;
                updatedEmp.Email = emp.Email;
                updatedEmp.Salary = emp.Salary;
                updatedEmp.DeptID = emp.DeptID;
                updatedEmp.Password = emp.Password;
                updatedEmp.JoinDate = emp.JoinDate;
                updatedEmp.Name = emp.Name;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.depts = new SelectList(context.Departments.ToList(), "ID", "Name");
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var emp = context.Employees.SingleOrDefault(e => e.ID == id);

                if (emp == null) return RedirectToAction("Index");

                context.Employees.Remove(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
