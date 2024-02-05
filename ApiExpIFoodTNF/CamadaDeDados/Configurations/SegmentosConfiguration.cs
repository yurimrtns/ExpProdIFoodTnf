using CamadaDeNegócios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CamadaDeDados.Configurations;

public class SegmentosConfiguration : IEntityTypeConfiguration<Segmento>
{
    public void Configure(EntityTypeBuilder<Segmento> builder)
    {
        builder.ToTable("Segmentos");
        builder.HasKey(e => e.Id);
        //builder.Property(e => e.IdSegmento).HasColumnName("id").IsRequired();
        builder.Property(e => e.Nome).HasColumnType("VARCHAR(40)").IsRequired();

    }
}
