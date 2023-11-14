using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.EntitiesConfiguration;

[ExcludeFromCodeCoverage]
public class HealthAssesmentConfiguration : IEntityTypeConfiguration<HealthAssesment>
{
    public void Configure(EntityTypeBuilder<HealthAssesment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("HealthAssesments");

        builder.HasOne(d => d.Plant).WithMany(p => p.HealthAssesments)
            .HasForeignKey(d => d.PlantId);
    }
}