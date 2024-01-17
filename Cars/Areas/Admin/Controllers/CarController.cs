using Cars.Context;
using Cars.Models;
using Cars.ViewModels.CarsVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        CarsDbContext _carcontext;
        public CarController(CarsDbContext carcontext)
        {
            _carcontext=carcontext;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _carcontext.AutoAccessories.Select(s => new AutoAccessoryListItemVM
            {
                Name = s.Name,
                Description= s.Description,
                Id = s.Id,
                ImgUrl = s.ImgUrl,

            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(AutoAccessoryCreateVM vm)
        {


            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            AutoAccessory autoAccessory = new AutoAccessory
            {
                Name = vm.Name,
                Description = vm.Description,
                ImgUrl = vm.ImgUrl,



            };
            await _carcontext.AutoAccessories.AddAsync(autoAccessory);
            await _carcontext.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return BadRequest();

            var data = await _carcontext.AutoAccessories.FindAsync(id);
            if (data == null) return NotFound();
            _carcontext.AutoAccessories.Remove(data);
            await _carcontext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id<=0) return BadRequest();
            var data = await _carcontext.AutoAccessories.FindAsync(id);
            if (data == null) return NotFound();
            return View(new AutoAccessoryUpdateVM
            {
                Name= data.Name,
                Description= data.Description,
                ImgUrl = data.ImgUrl,
            });
        }
        [HttpPost]

        public async Task<IActionResult> Update(AutoAccessoryUpdateVM vm, int id)
        {
            var data = await _carcontext.AutoAccessories.FindAsync(id);
            data.Name= vm.Name;
            data.Description= vm.Description;
            data.ImgUrl= vm.ImgUrl;

            await _carcontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
