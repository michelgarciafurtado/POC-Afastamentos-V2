using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC_Afastamentos_V2.core.domain.entities;

namespace POC_Afastamentos_V2.adapters.driven.Configurations
{
    public class RegraAfastamentoConfiguration : IEntityTypeConfiguration<RegraAfastamento>
    {
        public void Configure(EntityTypeBuilder<RegraAfastamento> builder)
        {
            builder.ToTable("RegrasAfastamentos");

            ///Configuracoes da chave primária
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasOne(r => r.TipoAfastamento)
                .WithMany()
                .HasForeignKey(r => r.TipoAfastamentoId);

            builder.Property(r => r.TipoRegra)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(r => r.Frequencia)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
