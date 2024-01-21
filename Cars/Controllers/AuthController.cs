using Cars.Models;
using Cars.ViewModels.AuthVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _roleManager=roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginVM vm)
        {
            AppUser user;
            if (vm.UsernameOrEmail.Contains("@"))
            {
               user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);

            }

            if (user == null)
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid) 
            {
                var user = new AppUser
                {
                    UserName = vm.Username,
                    Email = vm.Email,
                    Name = vm.Fullname,
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(vm);
        }
        
    }
}
