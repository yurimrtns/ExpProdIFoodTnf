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
        builder.Property(exp => exp.IdLojaIFood);
        builder.Property(exp => exp.Ativo);

        builder.HasOne(e => e.Empresa)
            .WithMany()
            .HasForeignKey(fk => fk.IdEmpresa);
        
        builder.HasOne(e => e.Categoria)
            .WithMany()
            .HasForeignKey(fk => fk.IdCategoria);
        
        builder.HasOne(e => e.Segmento)
            .WithMany()
            .HasForeignKey(fk => fk.IdSegmento);
    }
}
