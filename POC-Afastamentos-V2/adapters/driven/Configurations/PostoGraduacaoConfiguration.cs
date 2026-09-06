using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC_Afastamentos_V2.core.domain.entities;

namespace POC_Afastamentos_V2.adapters.driven.Configurations;

public class PostoGraduacaoConfiguration : IEntityTypeConfiguration<PostoGraduacao>
{
    public void Configure(EntityTypeBuilder<PostoGraduacao> builder)
    {
        builder.ToTable("Posto_Graducao");

        builder.HasKey(pg => pg.PosCod);

        builder.Property(pg => pg.PosCod)
            .HasColumnName("PosCod")
            .IsRequired();
        builder.Property(pg => pg.Sigla)
            .HasColumnName("Sigla")
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(pg => pg.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(pg => pg.Nivel)
            .HasColumnName("PosNivel")
            .IsRequired();
        builder.Property(pg => pg.Ativo)
            .HasColumnName("PosAtivo")
            .IsRequired();
    }
}
