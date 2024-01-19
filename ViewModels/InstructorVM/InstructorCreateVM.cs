using System.ComponentModel.DataAnnotations;

namespace EdukateMVC.ViewModels.InstructorVM
{
    public class InstructorCreateVM
    {
        [Required, MaxLength(32), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(32), MinLength(3)]
        public int ProfessionId { get; set; }
        public IFormFile Image { get; set; }
    }
}
