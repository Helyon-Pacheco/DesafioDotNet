using DesafioDotNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioDotNet.Infra.Data.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("varchar(1000)");

        builder.Property(p => p.Image)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.ToTable("Products");
    }
}
