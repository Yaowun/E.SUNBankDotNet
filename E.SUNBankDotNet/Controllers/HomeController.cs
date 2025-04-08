using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E.SUNBankDotNet.Models;

namespace E.SUNBankDotNet.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
