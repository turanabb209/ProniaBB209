using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB209.DAL;
using ProniaBB209.ViewModels.Products;

namespace ProniaBB209.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _contex;

        public ProductController(AppDbContext context)
        {
            _contex = context;
        }
        public async Task<IActionResult> Index()
        {
           List<GetproductVM> productVMs  = await _contex.Products.Select(p => new GetproductVM
            {   Name= p.Name,
                Price = p.Price,
                SKU= p.SKU,
                Id= p.Id,
                CategoryName=p.Category.Name,
                MainImages=p.ProductImages.FirstOrDefault(pi=>pi.IsPrimary==true).Image

            }).ToListAsync();

            return View();
        }
    }
}
