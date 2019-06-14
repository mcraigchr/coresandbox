using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sandbox.Controllers
{
    public class UserAccountController : Controller
    {
        private SandboxDbContext _sandboxDbContext;

        public UserAccountController(SandboxDbContext sandboxDbContext)
        {
            _sandboxDbContext = sandboxDbContext;
        }

        public IActionResult Login()
        {
            var model = new LoginViewModel();
            //return RedirectToAction("Index", "Customer");
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserData userData = new UserData(_sandboxDbContext);

                if (userData.Get(model.Username) != null)
                    return RedirectToAction("Details", "Customer");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName, Password = model.Password};
                _sandboxDbContext.Users.Add(user);
                _sandboxDbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View();
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
        public User Get(String ID)
        {
            return _context.Users.FirstOrDefault(e => e.UserName == ID);
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList<User>();
        }
    }

    public class LoginViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }

    public class RegisterUserViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
