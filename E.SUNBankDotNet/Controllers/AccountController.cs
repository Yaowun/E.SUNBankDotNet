using System.Security.Claims;
using E.SUNBankDotNet.Domains;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace E.SUNBankDotNet.Controllers;

public class AccountController : BaseController
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var customer = new Customer
        {
            UserID = model.UserID,
            UserName = model.UserName,
            Email = model.Email
        };
        
        if (ModelState.IsValid)
        {
            if (await _userService.IsUserExists(customer))
            {
                ModelState.AddModelError("UserID", "UserID exists");
                return View(model);
            }

            await _userService.CreateUser(customer);

            await SignInUser(customer);

            return RedirectToAction("Index", "Finance");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.Authenticate(new Customer
            {
                UserID = model.UserID,
                Email = model.Email,
            });
            if (user != null)
            {
                await SignInUser(user);
                
                return RedirectToAction("Index", "Finance");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }

    private async Task SignInUser(Customer customer)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, customer.UserID),
            new Claim(ClaimTypes.Email, customer.Email)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
    }
}