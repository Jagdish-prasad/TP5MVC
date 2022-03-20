using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TP5MVC.Models;

namespace TP5MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;
        private IHostingEnvironment Environment;

        public EmployeeController(ApplicationDbContext dbcontext, 
            IHostingEnvironment environment)
        {
            dbContext = dbcontext;
            Environment = environment;
        }  
        public IActionResult Index()
        {
            var emps = dbContext.Employee.ToList();
            return View(emps);
        }
       
        public IActionResult Create()
        {
            
            return View();
        } 
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var files = Request.Form.Files;
            string dbPath = string.Empty;
            if (files.Count > 0)
            {
                string path = Environment.WebRootPath;
                string fullpath = Path.Combine(path, "images", files[0].FileName);
                dbPath = "images/" + files[0].FileName;
                FileStream stream = new FileStream
                    (fullpath, FileMode.Create);
                files[0].CopyTo(stream);

            }
            employee.Image = dbPath;
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

            
        }
        public IActionResult Delete(int id)
        {
            var emp = dbContext.Employee.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                dbContext.Employee.Remove(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //Edit
        public IActionResult Edit(int id)
        {
            var emp = dbContext.Employee.SingleOrDefault(e => e.Id == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            dbContext.Employee.Update(emp);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }
    } 

}
