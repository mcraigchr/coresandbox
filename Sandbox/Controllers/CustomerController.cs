using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sandbox.Controllers
{
    public class CustomerController : Controller
    {
        private SandboxDbContext _sandboxDbContext;

        public CustomerController(SandboxDbContext sandboxDbContext)
        {
            _sandboxDbContext = sandboxDbContext;
        }

        [HttpGet]
        public IActionResult Details()
        {
            CustomerData sqlData = new CustomerData(_sandboxDbContext);
            CustomerViewModel model = new CustomerViewModel();
            model.Customers = sqlData.GetAll();

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(sqlData.GetAll());
        }
    }

    public class CustomerData
    {
        private SandboxDbContext _context { get; set; }
        public CustomerData(SandboxDbContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public Customer Get(String ID)
        {
            return _context.Customers.FirstOrDefault(x => x.UserName == ID);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList<Customer>();
        }
    }

    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
