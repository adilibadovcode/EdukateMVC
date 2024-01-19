using EdukateMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdukateMVC.Context
{
    public class EdukateContext : IdentityDbContext
    {
        public EdukateContext(DbContextOptions<EdukateContext> options) : base(options) { }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Profession> Professions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
