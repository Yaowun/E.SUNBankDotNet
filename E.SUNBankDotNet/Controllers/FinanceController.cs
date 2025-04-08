using Microsoft.AspNetCore.Mvc;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Services;

namespace E.SUNBankDotNet.Controllers;

public class FinanceController : Controller
{
    private readonly ILikeListService _likeListService;

    private readonly User _user = new()
    {
        UserID = "A1236456789",
        UserName = "testUser1",
        Email = "test1@email.com",
        Account = "1111999666"
    };

    public FinanceController(ILikeListService likeListService)
    {
        _likeListService = likeListService;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _likeListService.GetLikeList(_user);
        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(LikeProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _likeListService.AddLikeProduct(model, _user);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int SN)
    {
        var model = (await _likeListService.GetLikeProduct(_user)).FirstOrDefault(x => x.SN == SN);
        if (model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(LikeProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _likeListService.UpdateLikeProduct(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int SN)
    {
        var model = (await _likeListService.GetLikeProduct(_user)).FirstOrDefault(x => x.SN == SN);
        if (model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(LikeProductViewModel model)
    {
        await _likeListService.DeleteLikeProduct(model);
        return RedirectToAction("Index");
    }
}
