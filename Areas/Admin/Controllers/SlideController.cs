using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using ProniaBB209.DAL;
using ProniaBB209.Models;
using ProniaBB209.Utilities.Enums;
using ProniaBB209.Utilities.Extensions;
using ProniaBB209.ViewModels;

using System.Threading.Tasks;

namespace ProniaBB209.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideController : Controller
    {
       
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SlideController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<GetSlideVM> slideVMs = await _context.Slides.Select(s =>
            new GetSlideVM 
            { Id=s.Id,
                Title = s.Title,
                Image=s.Image,
                CreatedAt=s.CreateAt,
                Order=s.Order
                
            }).ToListAsync();





            return View(slideVMs);

            ////List<GetSlideVM> slideVMs = new List<GetSlideVM>();
            ////foreach (var slide in slides)
            ////{
            ////    slideVMs.Add(new GetSlideVM

            ////    {
            ////        CreatedAt = slide.CreateAt,
            ////        Title = slide.Title,
            ////        Image = slide.Image,
            ////        Id = slide.Id,
            ////        Order = slide.Order,
            ////    });

            ////} 





        }

        //public string Test()
        //{

        //    return Guid.NewGuid().ToString();
        //}

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSlideVM slideVM)
        {    
            if(!ModelState.IsValid) return View();

            //!FileValidator.ValidateType(slide.Photo, "image/")
            if (!slideVM.Photo.ValidateType("image/"))
            {
                ModelState.AddModelError(nameof(CreateSlideVM.Photo), "File type is incorrect");
                return View();
            }

            if (slideVM.Photo.ValidateSize(FileSize.MB, 10))
            {
                ModelState.AddModelError(nameof(CreateSlideVM.Photo), "File size should be less than 10MB");
                return View();
            }

           

            
         string fileName = await slideVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"); ;

            Slide slide = new Slide
            { 
                Title = slideVM.Title,
                Subtitle = slideVM.Subtitle,
                Describtion = slideVM.Describtion,
                Order = slideVM.Order,
                Image=fileName,
                CreateAt = DateTime.Now
            };           
         
            await _context.Slides.AddAsync(slide);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            //return Content(slide.Photo.FileName+" "+ slide.Photo.ContentType+" "+ slide.Photo.Length);
            //if (!ModelState.IsValid) return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            Slide? slide = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);
            if(slide is null ) return NotFound();

           slide.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            _context.Remove(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


























        //Update check
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            Slide? slide = await _context.Slides.FirstOrDefaultAsync(c => c.Id == id);
            if (slide is null) return NotFound();


            return View(slide);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Slide slide)
        {

            if (!ModelState.IsValid) return View();


            bool result = await _context.Slides.AnyAsync(s => s.Title == slide.Title && s.Id != id);
            if (result)
            {
                ModelState.AddModelError(nameof(Slide.Title), $"{slide.Title} named category already exists");
                return View();
            }


            Slide? existed = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);

            if (existed.Title == slide.Title) return RedirectToAction(nameof(Index));

            existed.Title = slide.Title;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }































        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id is null || id <= 0) return BadRequest();

        //    Slide? slide = await _context.Slides.FirstOrDefaultAsync(c => c.Id == id);

        //    if (slide is null) return NotFound();

        //    //if (category.IsDeleted)
        //    //{
        //    //    category.IsDeleted = false;
        //    //}
        //    //else
        //    //{
        //    //    category.IsDeleted = true;
        //    //}

        //    //omurluk silmek ucun:

        //    _context.Slides.Remove(slide);

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
