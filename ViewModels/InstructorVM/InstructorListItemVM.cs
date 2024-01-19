using EdukateMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace EdukateMVC.ViewModels.InstructorVM
{
    public class InstructorListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Profession? Profession { get; set; }
        public string Image { get; set; }
    }
}
