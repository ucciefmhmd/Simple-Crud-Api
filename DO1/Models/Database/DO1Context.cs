using DO1.Models.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DO1.Models.Database
{
    public class DO1Context : DbContext
    {
        public DO1Context(DbContextOptions<DO1Context> opt):base(opt) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
