using System.Threading.Tasks;
using EventBookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager; 
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr) 
        { 
            userManager = userMgr; 
            signInManager = signInMgr; 
        }
        [AllowAnonymous] 
        public ViewResult Login(string returnUrl) 
        {
            return View(new LoginModel 
            {
                ReturnUrl = returnUrl
            }); 
        }

        [HttpPost] 
        [AllowAnonymous] 
        [ValidateAntiForgeryToken] 
        // [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Login(LoginModel loginModel) 
        {
            if (ModelState.IsValid) 
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null) 
                { 
                    await signInManager.SignOutAsync(); 
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded) 
                    { 
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Index"); 
                    } 
                }
            }
            ModelState.AddModelError("", "Invalid name or password"); 
            return View(loginModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout() 
        {
            await signInManager.SignOutAsync(); 
            return RedirectToAction("Index","Home"); 
        }
    }
}