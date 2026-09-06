using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC_Afastamentos_V2.core.domain.aggregates;

namespace POC_Afastamentos_V2.adapters.driven.Configurations
{
    public class PolicialConfiguration : IEntityTypeConfiguration<Policial>
    {
        public void Configure(EntityTypeBuilder<Policial> builder)
        {
            builder.ToTable("Policial");

            builder.HasKey(p => p.Re);

            builder.Property(p => p.Re)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(p => p.Dg)
                .IsRequired()
                .HasMaxLength(2);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);
            builder.HasOne(p => p.PostoGraduacao)
                .WithMany()
                .HasForeignKey(p => p.PosCod);  
            builder.HasOne(p => p.Opm)
                .WithMany()
                .HasForeignKey(p => p.OpmCod);
        }
    }
}
