using Microsoft.EntityFrameworkCore;
using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using System.Reflection.Emit;

namespace POC_Afastamentos_V2.adapters.driven.ConnectionDB;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    DbSet<Policial> Policiais { get; set; }
    DbSet<Opm> Opms { get; set; }
    DbSet<PostoGraduacao> PostosGraduacoes { get; set; }
    DbSet<Afastamentos> Afastamentos { get; set; }
    DbSet<SolicitacaoAfastamento> SolicitacoesAfastamentos { get; set; }
}