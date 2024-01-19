using EdukateMVC.Context;
using EdukateMVC.Helpers;
using EdukateMVC.Models;
using EdukateMVC.ViewModels.InstructorVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EdukateMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class InstructorController : Controller
    {
        EdukateContext _db { get; }

        public InstructorController(EdukateContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Profession = _db.Professions;
            var data = await _db.Instructors.Select(x => new InstructorListItemVM
            {
                Name = x.Name,
                Id = x.Id,
                Image = x.Image,
                Profession=x.Profession,
            }).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Profession = _db.Professions;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InstructorCreateVM vm)
        {
                ViewBag.Profession = _db.Professions;

            if (!ModelState.IsValid)
            {
                ViewBag.Profession = _db.Professions;
                return View(vm);
            }
            Instructor instructor = new Instructor
            {
                Image = await vm.Image.SaveAsync(PathConstants.Instructor),
                ProfessionId = vm.ProfessionId,
                Name = vm.Name,
            };
            await _db.Instructors.AddAsync(instructor);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Instructors.FindAsync(Id);
            if (data == null) return NotFound();
            ViewBag.Profession = _db.Professions;

            return View(new InstructorUpdateVM
            {
                Name = data.Name,
                //ProfessionId = data.ProfessionId
            });
        }
        [HttpPost]

        public async Task<IActionResult> Update(int? Id, InstructorUpdateVM vm)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Profession = _db.Professions;

                return View(vm);
            }
            ViewBag.Profession = _db.Professions;
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Instructors.FindAsync(Id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            data.Image = await vm.Image.SaveAsync(PathConstants.Instructor);
            data.ProfessionId =vm.ProfessionId;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Instructors.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Instructors.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
