using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.EntitiesConfiguration;
[ExcludeFromCodeCoverage]
public class PlantConfiguration : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("Plants");

        builder.Property(e => e.Description)
            .HasMaxLength(255);

        builder.HasOne(d => d.User).WithMany(p => p.Plants)
            .HasForeignKey(d => d.UserId);
    }
}