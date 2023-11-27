using Dotnet8ModuleSubmodule.Entities.Tagging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet8ModuleSubmodule.Data.Configuration
{
    public class ModuleSubModuleConfiguration : IEntityTypeConfiguration<ModuleSubModuleTagging>
    {
        public void Configure(EntityTypeBuilder<ModuleSubModuleTagging> builder)
        {
            // Define the primary key
            builder.HasKey(msm => new { msm.ModuleId, msm.SubModuleId });

            // Configure the foreign key relationships
            // Configure the relationship with the Module entity
            builder.HasOne(msm => msm.Module)
                .WithMany(m => m.ModuleSubModules)
                .HasForeignKey(msm => msm.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);  // Changed to prevent cascade delete

            // Configure the relationship with the SubModule entity
            builder.HasOne(msm => msm.SubModule)
                .WithMany(sm => sm.ModuleSubModules)
                .HasForeignKey(msm => msm.SubModuleId)
                .OnDelete(DeleteBehavior.Restrict);  // Changed to prevent cascade delete
        }
    }
}