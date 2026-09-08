using Microsoft.EntityFrameworkCore;
using POC_Afastamentos_V2.core.domain.entities;

namespace POC_Afastamentos_V2.adapters.driven.Configurations;

public class AfastamentoConfiguration:IEntityTypeConfiguration<Afastamentos>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Afastamentos> builder)
    {
        builder.ToTable("Afastamento");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(a => a.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(a => a.Ativo)
            .HasColumnName("Ativo");
         
    }      
}
