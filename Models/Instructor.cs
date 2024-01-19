using System.ComponentModel.DataAnnotations;

namespace EdukateMVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required,MaxLength(32),MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(32), MinLength(3)]
        public int? ProfessionId { get; set; }
        public Profession? Profession { get; set; }
        public string Image { get; set; }
    }
}
