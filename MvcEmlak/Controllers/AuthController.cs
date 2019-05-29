using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcEmlak.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcEmlak.Controllers
{
    public class AuthController : Controller
    {
        private readonly MvcEmlakContext _context;

        public AuthController(MvcEmlakContext context)
        {
            _context = context;
        }

        // GET: /Auth/Login
        public IActionResult Login()
        {
            if (!String.IsNullOrEmpty(Request.Cookies["userID"]))
            {
                return RedirectToAction("Index", "Home");

            }
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            User foundUser = _context.User.SingleOrDefault(user => user.Username == username);
            if (foundUser == null)
            {
                return View();
                
            }

            if (foundUser.Password == password)
            {
                HttpContext.Response.Cookies.Append("userName", foundUser.Username, new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(5)

                });
                HttpContext.Response.Cookies.Append("userID", foundUser.Id.ToString(), new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(5)

                });
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("userName");
            HttpContext.Response.Cookies.Delete("userID");

            return RedirectToAction("Index", "Home");
        }

        // GET: /Auth/Register
        public IActionResult Register()
        {
            if (!String.IsNullOrEmpty(Request.Cookies["userID"]))
            {
                return RedirectToAction("Index", "Home");

            }
            return View();
        }

        // POST: /Auth/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Name,Surname,Email,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: /Auth/
        public IActionResult Index()
        {
            return RedirectToAction("Login", "Auth");
        }
    }
}
