using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForTec.Domain.Entities;

public class RelatorioConfiguration : IEntityTypeConfiguration<RelatorioEntity>
{
    public void Configure(EntityTypeBuilder<RelatorioEntity> builder)
    {
        builder.ToTable("Relatorios");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.DataSolicitacao)
               .IsRequired();

        builder.Property(r => r.Arbovirose)
               .HasMaxLength(50);

        builder.Property(r => r.SemanaInicio);
        builder.Property(r => r.SemanaFim);
        builder.Property(r => r.CodigoIbge)
               .HasMaxLength(10);

        builder.Property(r => r.Municipio)
               .HasMaxLength(100);

        builder.HasOne(r => r.Solicitante)
               .WithMany()
               .HasForeignKey("SolicitanteId")
               .IsRequired();
    }
}
