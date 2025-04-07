using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Repositories;
using E.SUNBankDotNet.Services;

namespace E.SUNBankDotNet.Controllers;

public class FinanceController : Controller
{
    private readonly ILikeListService _likeListService;
    private const string UserId = "A1236456789"; // TODO: Need Login function to identify user

    public FinanceController(ILikeListService likeListService)
    {
        _likeListService = likeListService;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _likeListService.GetLikeList(UserId);
        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(LikeListViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.UserID = UserId;
            await _likeListService.AddLikeProduct(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int productNo)
    {
        var list = await _likeListService.GetLikeList(UserId);
        var item = list.FirstOrDefault(x => x.ProductNo == productNo);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(LikeListViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.UserID = UserId;
            Console.WriteLine(model.ProductNo);
            await _likeListService.UpdateLikeProduct(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int productNo)
    {
        var list = await _likeListService.GetLikeList(UserId);
        var item = list.FirstOrDefault(x => x.ProductNo == productNo);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(LikeListViewModel model)
    {
        await _likeListService.DeleteLikeProduct(model);
        return RedirectToAction("Index");
    }
}
