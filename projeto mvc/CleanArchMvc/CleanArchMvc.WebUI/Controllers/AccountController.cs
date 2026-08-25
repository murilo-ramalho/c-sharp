using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;
        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var result = await _authenticate.Authenticate(
                new CleanArchMvc.Domain.Entities.Email(loginViewModel.Email),
                loginViewModel.Password);

            if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            if (result)
            {
                return Redirect(loginViewModel.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt. (password must be strong).");
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) 
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var result = await _authenticate.RegisterUser(
                new CleanArchMvc.Domain.Entities.Email(registerViewModel.Email),
                registerViewModel.Password);

            if (result)
            {
                return Redirect("/");
            }

            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }
    }
}
