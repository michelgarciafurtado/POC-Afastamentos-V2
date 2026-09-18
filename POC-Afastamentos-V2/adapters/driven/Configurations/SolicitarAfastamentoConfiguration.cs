using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.valueobjects;
using System.Text.Json;

namespace POC_Afastamentos_V2.adapters.driven.Configurations
{
    public class SolicitarAfastamentoConfiguration : IEntityTypeConfiguration<SolicitacaoAfastamento>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAfastamento> builder)
        {
            builder.ToTable("Solicitacao_Afastamentos");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).IsRequired();

            builder.HasOne(s => s.Interessado)
                .WithMany()
                .HasForeignKey(s => s.InteressadoRe)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(s => s.Solicitante)
                .WithMany()
                .HasForeignKey(s => s.SolicitanteRe)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(s => s.Opm)
                .WithMany()
                .HasForeignKey(s => s.OpmCod)
                .IsRequired();

            builder.HasOne(s => s.TipoAfastamento)
                .WithMany()
                .HasForeignKey(s => s.TipoAfastamentoId)
                .IsRequired();

           builder.Property(s => s.DetalhesAfastamento)
                .HasColumnName("DetalhesAfastamento")
                .HasColumnType("nvarchar(max)")
                .HasConversion(
                    detalhes => JsonSerializer.Serialize(detalhes,
                                    (JsonSerializerOptions) null),
                    json => JsonSerializer.Deserialize<DetalhesAfastamento>(json, (JsonSerializerOptions?)null)!
                );
        }
    }
}
