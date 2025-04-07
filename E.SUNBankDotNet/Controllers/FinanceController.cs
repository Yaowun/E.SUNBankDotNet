using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Repositories;

namespace E.SUNBankDotNet.Controllers;

public class FinanceController : Controller
{
    private readonly FinanceDBRepo _financeDBRepo;

    public FinanceController(FinanceDBRepo financeDBRepo)
    {
        _financeDBRepo = financeDBRepo;
    }

    public async Task<IActionResult> Index()
    {
        string userId = "A1236456789";
        var likeList = await _financeDBRepo.GetLikeListByUser(userId);

        if (likeList != null && likeList.Any())
        {
            ViewBag.Message = likeList.First().Account;
        }
        else
        {
            ViewBag.Message = "failed";
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
