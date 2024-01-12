using CamadaDeNegócios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CamadaDeDados.Configurations;

public class EmpresasConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresas");
        builder.HasKey(e  => e.Id);
        builder.Property(e => e.Nome).HasColumnType("VARCHAR(40)").IsRequired();

    }
}
