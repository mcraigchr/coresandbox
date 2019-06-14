using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Models;

namespace Sandbox.Controllers
{
    public class HomeController : Controller
    {
        private SandboxDbContext _sandboxDbContext;

        public HomeController (SandboxDbContext sandboxDbContext)
        {
            _sandboxDbContext = sandboxDbContext;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();

            //using (var context = new SandboxDbContext())
            //{
                UserData sqlData = new UserData(_sandboxDbContext);
                model.Users = sqlData.GetAll();
            //}
            return View(model);
        }
    }
    public class UserData
    {
        private SandboxDbContext _context { get; set; }
        public UserData(SandboxDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User Get(int ID)
        {
            return _context.Users.FirstOrDefault(e => e.Id == ID);
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList<User>();
        }
    }
    public class HomePageViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
