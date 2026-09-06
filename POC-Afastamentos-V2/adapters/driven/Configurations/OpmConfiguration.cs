using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC_Afastamentos_V2.core.domain.entities;

namespace POC_Afastamentos_V2.adapters.driven.Configurations
{
    public class OpmConfiguration : IEntityTypeConfiguration<Opm>
    {
        public void Configure(EntityTypeBuilder<Opm> builder)
        {
            builder.ToTable("Opm");
            builder.HasKey(o => o.OpmCod);
            builder.Property(o => o.OpmCod)
                .HasColumnName("OpmCod")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(o => o.NomeOpm)
                .HasColumnName("NomeOpm")
                .HasMaxLength(150)
                .IsRequired();


        }
    }
}
