using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecurityApp.Core;
using SecurityApp.Core.Models;

namespace SecurityApp.Repo.Data
{

    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Database.Migrate();
            //modelBuilder.ApplyConfiguration(new TeacherData());
            //modelBuilder.ApplyConfiguration(new StudentData());
        }

    }
}