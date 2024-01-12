using CamadaDeDados.Configurations;
using CamadaDeNegócios.Entities;
using Microsoft.EntityFrameworkCore;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace CamadaDeDados;

public class ExpIFoodContext : TnfDbContext
{
    public ExpIFoodContext(DbContextOptions<ExpIFoodContext> options, ITnfSession session) : base(options, session)
    {
    }

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Segmento> Segmentos { get; set; }
    public DbSet<ExpProdIFood> ExpProdIFood { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmpresasConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriasConfiguration());
        modelBuilder.ApplyConfiguration(new SegmentosConfiguration());
        modelBuilder.ApplyConfiguration(new ExpProdIFoodConfiguration());
    }
}
