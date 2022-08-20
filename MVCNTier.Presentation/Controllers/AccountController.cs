using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCNTier.BLL.Models.DTOs;
using MVCNTier.BLL.Services.AppUserService;
using System.Threading.Tasks;

namespace MVCNTier.Presentation.Controllers
{
    [Authorize] //Bu controller'a erişim log in olmuş kullanıcılar tarafından sağlanabilir
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly IAppUserService appUserService;
        public AccountController(IAppUserService appUserService)
        {
            this.appUserService = appUserService;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index",nameof(Areas.Member.Controllers.HomeController));
            }
            return View();
        }

        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await appUserService.Register(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Member" });
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                    TempData["Error"] = "Oppps... Something went wrong :(";
                }

            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Member" });
            }
            return View();
        }

        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await appUserService.LogIn(model);
                if (result.Succeeded) return RedirectToAction("Index", "Home", new { area = "Member" });
            }
            return View();
        }
    }
}
