using EdukateMVC.Context;
using EdukateMVC.ViewModels.InstructorVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdukateMVC.Controllers
{
    public class HomeController : Controller
    {
        EdukateContext _db { get; }

        public HomeController(EdukateContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Profession = _db.Instructors;
            var data = await _db.Instructors.Select(x => new InstructorListItemVM
            {
                Name = x.Name,
                Id = x.Id,
                Image = x.Image,
                Profession = x.Profession,
            }).ToListAsync();
            return View(data);
        }
    }
}