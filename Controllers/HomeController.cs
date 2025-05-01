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

        public IActionResult Index()
        {
          

            HomeVM homeVM = new HomeVM 
            {
             

                Slides = _context.Slides.OrderBy(s => s.Order).Take(2).ToList(),
               Products = _context.Products.Take(13).
               Include(p => p.ProductImages.Where(pi=>pi.IsPrimary!=null))
               .ToList()

             

            };



            return View(homeVM);
        }



        //1.DI-Dependency Injection -(Asılılığın yeridilməsi)- /Pattern en meshuru budu-bu sablondu bu olmasa IOC ede bilirem, backendde en effektlisi budu, 3 novu var 
        //2.IOC- Inverse of Control -(Nəzarətin tərsinə çevrilməsi)- /Principle-sen yaratma idaresini kenara ver yeni sen yaratma 
        //3.Service LifeTime -(Xidmətin yaşam müddəti)
        // 3 novu olur:
        // *Singleton-layihe yarananda yaranir ve cokene qeder qalir obyektler
        // *Scoped- her sorgu ucun bir defe yaranir ve sorgu bitdikde silinir
        // *Transient-her miraciet ucun ayrica yaranir ve silinir, toplama cixma ve s. appdbcontextde bele isleyir
        //4.IOC Container/ DI Container -(Asılılıq idarəetmə konteyneri, IOC və DI prinsiplərini həyata keçirən bir mexanizmdir.)-
        //IOc vasitesile yaranan obyektleri saxlayan konteynerlerdi ve hara lazimdi ora gonderir

        //DIP-Dependency Inversion Principle -(Asılılıqların tərsinə çevrilməsi prinsipi , Hər iki modul(yeni hem high level classlarimiz hem low level classlarimizdan, Hər ikisi abstraksiyalardan (interface və ya abstract class)  esasen interfaceden asılı olmalıdır.") bir interface-dən istifadə etsin:)-
        //DIP-ni Solidde gormusduk, melumat bazasi low moduldu. Abstractiondan asili olmalisan
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //













    }
}
