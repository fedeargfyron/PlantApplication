using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.EntitiesConfiguration;

[ExcludeFromCodeCoverage]
public class PlantRiskConfiguration : IEntityTypeConfiguration<PlantRisk>
{
    public void Configure(EntityTypeBuilder<PlantRisk> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("PlantRisks");

        builder.HasOne(d => d.Plant).WithMany(p => p.PlantRisks)
            .HasForeignKey(d => d.PlantId);
    }
}