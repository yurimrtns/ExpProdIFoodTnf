using CamadaDeNegócios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamadaDeDados.Configurations;

public class ExpProdIFoodConfiguration : IEntityTypeConfiguration<ExpProdIFood>
{
    public void Configure(EntityTypeBuilder<ExpProdIFood> builder)
    {
        builder.ToTable("ExpProdIFood");
        builder.HasKey(exp => exp.Id);
        builder.Property(exp => exp.IdLojaIFood).IsRequired();
        builder.Property(exp => exp.Ativo).IsRequired();
        builder.HasOne(exp => exp.Empresa)
            .WithMany()
            .HasForeignKey(exp => exp.IdEmpresa);
        builder.HasOne(exp => exp.Categoria)
            .WithMany()
            .HasForeignKey(exp => exp.IdCategoria);
        builder.HasOne(exp => exp.Segmento)
            .WithMany()
            .HasForeignKey(exp => exp.IdSegmento);
    }
}
