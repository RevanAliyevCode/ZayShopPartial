using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayShopMVC.Data;
using ZayShopMVC.Models.Shop;

namespace ZayShopMVC.Controllers
{
    public class ShopController : Controller
    {
        readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ShopVM model = new ShopVM();

            List<CategoryVM> categories = _context.Categories.Select(x => new CategoryVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            model.Categories = categories;

            List<ProductVM> products = _context.Products.Include(p => p.Sizes).Select(x => new ProductVM
            {
                Name = x.Name,
                Price = x.Price,
                ImageName = x.ImageName,
                Rating = x.Rating,
                Sizes = x.Sizes.Select(s => s.Name).ToList()
            }).ToList();

            model.Products = products;

            return View(model);
        }

        [HttpGet]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var productsQuery = _context.Products.Include(p => p.Sizes).AsQueryable();

            if (categoryId != 0)
            {
                productsQuery = productsQuery.Where(x => x.CategoryId == categoryId);
            }

            List<ProductVM> products = productsQuery.Select(x => new ProductVM
            {
                Name = x.Name,
                Price = x.Price,
                ImageName = x.ImageName,
                Rating = x.Rating,
                Sizes = x.Sizes.Select(s => s.Name).ToList()
            }).ToList();


            return PartialView("_ProductPartial", products);
        }

    }
}
