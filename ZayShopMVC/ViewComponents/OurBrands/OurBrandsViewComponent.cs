using System;
using Microsoft.AspNetCore.Mvc;
using ZayShopMVC.Data;

namespace ZayShopMVC.ViewComponents.OurBrands;

public class OurBrandsViewComponent : ViewComponent
{
    readonly AppDbContext _context;

    public OurBrandsViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var model = _context.OurBrands.ToList();
        return View(model);
    }
}
