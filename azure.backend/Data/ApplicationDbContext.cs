using Microsoft.EntityFrameworkCore;
using TerapiaApp.API.Models;

namespace TerapiaApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TherapyTask> TherapyTasks { get; set; }
    }
}