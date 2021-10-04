using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shopApp.WEBUI.Data;
using shopApp.WEBUI.Models;

namespace shopApp.WEBUI.Controllers
{
    public class UserController : Controller
    {


        private UserManager<User> _userManager;

        private SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            
            
                return View();
            
           // return Redirect("/home/index");
           
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(UserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Email = userData.Email;
                user.UserName = userData.UserName;

                var result = await _userManager.CreateAsync(user, userData.Password);

                if (result.Succeeded)
                    return Redirect("/Home/index");
                //return Ok();
                else
                {
                    result.Errors.ToList().ForEach(a => ModelState.AddModelError("", a.Description));

                }

            }
            return View(userData);
        }

        public IActionResult List()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpGet]

        public async Task<IActionResult> Update(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return View(result);
        }
        [HttpPost]

        public async Task<IActionResult> Update(User newUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(newUser.Id);
                user.UserName = newUser.UserName;
                user.Email = newUser.Email;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("List");
                else
                {
                    result.Errors.ToList().ForEach(a => ModelState.AddModelError("", a.Description));
                }
            }
            return View(newUser);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("List");
        }

        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserData user)
        {
            
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

            if (result.Succeeded)
            {
               
                return RedirectToAction("List");
            }

            ModelState.AddModelError("", "Incorrect username or password");
            
            return View(user);

        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}