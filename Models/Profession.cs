namespace EdukateMVC.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Instructor> Instructor { get; set; }
    }
}
