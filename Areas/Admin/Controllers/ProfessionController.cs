using EdukateMVC.Context;
using EdukateMVC.Helpers;
using EdukateMVC.Models;
using EdukateMVC.ViewModels.InstructorVM;
using EdukateMVC.ViewModels.ProfessionVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdukateMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]

    public class ProfessionController : Controller
    {
        EdukateContext _db { get; }

        public ProfessionController(EdukateContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Professions.Select(x => new ProfessionListItemVM
            {
                Name = x.Name,
                Id = x.Id,
            }).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfessionCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Profession profession = new Profession
            {
                Name = vm.Name,
            };
            await _db.Professions.AddAsync(profession);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Professions.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Professions.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
