using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E.SUNBankDotNet.Models;

namespace E.SUNBankDotNet.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
