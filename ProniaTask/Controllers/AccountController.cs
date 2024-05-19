using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaTask.Models;
using ProniaTask.ViewModels.Account;

namespace ProniaTask.Controllers
{
    public class AccountController(UserManager<AppUser>_userManager, SignInManager<AppUser>_signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            AppUser user = new AppUser
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.Name
            };
            IdentityResult result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if(!ModelState.IsValid)return View(vm);
            AppUser? user = await _userManager.FindByNameAsync(vm.UserNameorEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(vm.UserNameorEmail);
                if(user == null)
                {
                    ModelState.AddModelError("", "Istifadəçi tapılmadı.");
                }
            }
            if(!await _userManager.CheckPasswordAsync(user, vm.Password))
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrəsi yanlışdır." + user.LockoutEnd.Value.ToString("HH:mm:ss"));
                return View(vm);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Çox sayda yanlış dəyər göndərdiniz. Zəhmət olmasa gözləyin.");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
