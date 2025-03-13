using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MIDTERM_PT2_BONIEL.Models;

namespace MIDTERM_PT2_BONIEL.Controllers
{
        public class HomeController : Controller
        {
            // Temporary in-memory storage for registered users
            private static List<UserModel> Users = new List<UserModel>();

            // Display the Login form
            public IActionResult Index()
            {
                return View();
            }

            // Display the Registration form
            public IActionResult Register()
            {
                return View();
            }

            // Handle registration form submission
            [HttpPost]
            public IActionResult Register(UserModel model)
            {
                if (ModelState.IsValid)
                {
                    Users.Add(model); // Store user in memory
                    ViewBag.RegistrationMessage = "Registration successful! Please log in.";
                    return RedirectToAction("Index"); // Redirect to Login after registration
                }
                return View(model);
            }

            // Handle login form submission
            [HttpPost]
            public IActionResult Login(LoginModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = Users.Find(u => u.Email == model.Email && u.Password == model.Password);
                    if (user != null)
                    {
                        ViewBag.LoginMessage = "Login successful!";
                    }
                    else
                    {
                        ViewBag.LoginMessage = "Invalid email or password.";
                    }
                }
                return View("Index", model);
            }
        }
}

