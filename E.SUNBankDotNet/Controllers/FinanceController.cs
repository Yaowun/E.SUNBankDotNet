using E.SUNBankDotNet.Domains;
using Microsoft.AspNetCore.Mvc;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Services;
using Microsoft.AspNetCore.Authorization;

namespace E.SUNBankDotNet.Controllers;

[Authorize]
public class FinanceController : BaseController
{
    private readonly ILikeListService _likeListService;

    public FinanceController(ILikeListService likeListService)
    {
        _likeListService = likeListService;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _likeListService.GetLikeList(GetCustomer());
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
            await _likeListService.AddLikeProduct(model, GetCustomer());
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int SN)
    {
        var model = (await _likeListService.GetLikeProduct(GetCustomer())).FirstOrDefault(x => x.SN == SN);
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
        var model = (await _likeListService.GetLikeProduct(GetCustomer())).FirstOrDefault(x => x.SN == SN);
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
