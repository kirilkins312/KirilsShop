using KirilsShop.Data;
using KirilsShop.Data.Static;
using KirilsShop.Models;
using KirilsShop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KirilsShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _appDbContext;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext; 
            _userManager = userManager;
            _signInManager = signInManager;
        }

            
        public IActionResult Login() => View(new LoginVM());


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) { return View(loginVM); }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null) { 
            
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password,false,false);
                    if (result.Succeeded) {
                    
                        return RedirectToAction("Index", "Cars");
                    }
                }
            }

            TempData["Error"] = "Wrong credential. Please, Try again";

            return View(loginVM);

        }

        public IActionResult Register() => View(new SignInVM());

        [HttpPost]
        public async Task<IActionResult> Register(SignInVM signInVM)
        {
            if (!ModelState.IsValid) { return View(signInVM); }

            var user = await _userManager.FindByEmailAsync(signInVM.EmailAddress);
            if (user == null)
            {
                var newUser = new ApplicationUser()
                {
                    FullName = signInVM.FullName,
                    Email = signInVM.EmailAddress,
                    UserName = signInVM.EmailAddress

                };

                var newUserResponse = await _userManager.CreateAsync(newUser, signInVM.Password);
                
                if (newUserResponse.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                }

                return View("RegisterCompleted");
            }

            TempData["Error"] = "This email is alread taken";

            return View(signInVM);

        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Cars");
        }

    }


}
