using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        public IActionResult Details(String UserId)
        {
            UserData sqlData = new UserData(_sandboxDbContext);
            var model = sqlData.Get(UserId);

            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(String UserId)
        {
            UserData sqlData = new UserData(_sandboxDbContext);
            var model = sqlData.Get(UserId);

            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

    public class HomePageViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }

}
