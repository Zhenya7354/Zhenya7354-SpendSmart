using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpendSmart_Second_Web_application_.Models;

namespace SpendSmart_Second_Web_application_.Controllers
{
    //Install packets Identity and IdentityFrameworkCore
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _SignInManager;
        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _SignInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid) { return View(login); }
            var result = await _SignInManager.PasswordSignInAsync(login.Name, login.Password, false, false);
            if (result.Succeeded)
            { return RedirectToAction("Index", "Home"); }
            return View(login);
        }

        public async Task<IActionResult> Register(Register register)
        {
            if (!ModelState.IsValid) { return View(register); }

            var newUser = new UserModel
            {
                UserName = register.Name,
                Email = register.Email,
            };
            var result = await _userManager.CreateAsync(newUser,register.Password);
            if(result.Succeeded)
            {
                await _SignInManager.PasswordSignInAsync(newUser,register.Password,false,false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            _SignInManager.SignOutAsync();
            return RedirectToAction("Authorization","Home");
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteUserAsync(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    if(user == null)
        //    {
        //        return NotFound("UserNotFound");
        //    }
        //    var result = await _userManager.DeleteAsync(user);

        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Account","Authorization");
        //    }

        //    return View();
        //}

        

       
    }
}
