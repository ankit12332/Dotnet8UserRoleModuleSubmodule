using Dotnet8ModuleSubmodule.Data.Configuration;
using Dotnet8ModuleSubmodule.Entities;
using Dotnet8ModuleSubmodule.Entities.Tagging;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8ModuleSubmodule.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ModuleSubModuleConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<SubModule> SubModules { get; set; }
        public DbSet<ModuleSubModuleTagging> ModuleSubModuleTaggings { get; set; }

    }
}
