using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.EntitiesConfiguration;

[ExcludeFromCodeCoverage]
public class WateringDayConfiguration : IEntityTypeConfiguration<WateringDay>
{
    public void Configure(EntityTypeBuilder<WateringDay> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("WateringDays");

        builder.HasOne(d => d.Plant).WithMany(p => p.WateringDays)
            .HasForeignKey(d => d.PlantId);
    }
}