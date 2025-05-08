using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB209.DAL;
using ProniaBB209.Models;
//using ProniaBB209.Services;
using ProniaBB209.ViewModels;

namespace ProniaBB209.Controllers
{
    public class HomeController:Controller
    {
        public  readonly AppDbContext _context;
        //private readonly IEmailService _service;

        public HomeController(AppDbContext context) //+,IEmailService service
        {
            _context = context;
            //_service = service;
        }

        public async Task<IActionResult> Index()
        {
          

            HomeVM homeVM = new HomeVM 
            {
             

                Slides = await _context.Slides
                .OrderBy(s => s.Order)
                .Take(2)
                .ToListAsync(),

               Products = await _context.Products
               .Take(13).
               Include(p => p.ProductImages.Where(pi=>pi.IsPrimary!=null))
               .ToListAsync()             

            };
            return View(homeVM);
        }      
    }
}
