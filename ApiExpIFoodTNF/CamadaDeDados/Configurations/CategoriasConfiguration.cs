using CamadaDeNegócios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CamadaDeDados.Configurations;

public class CategoriasConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(e  => e.Id);

        //builder.Property(e => e.IdCategoria).HasColumnName("id").IsRequired();
        builder.Property(e => e.Nome).HasColumnType("VARCHAR(40)").IsRequired();

    }
}
