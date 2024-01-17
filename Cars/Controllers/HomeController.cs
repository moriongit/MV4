using Cars.Context;
using Cars.Models;
using Cars.ViewModels.CarsVM;
using Cars.ViewModels.HomeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Cars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CarsDbContext _carcontext;
        public HomeController(CarsDbContext carsDbContext) 
        {
            _carcontext = carsDbContext;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                AutoAccessories = await _carcontext.AutoAccessories.Select(x => new AutoAccessoryListItemVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImgUrl = x.ImgUrl,
                }).ToListAsync()
            };
            return View(vm);
        }

    }
}