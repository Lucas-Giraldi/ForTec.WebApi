using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForTec.Domain.Entities;

public class SolicitanteConfiguration : IEntityTypeConfiguration<SolicitanteEntity>
{
    public void Configure(EntityTypeBuilder<SolicitanteEntity> builder)
    {
        builder.ToTable("tb_solicitantes");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
               .IsRequired();

        builder.Property(s => s.Cpf)
               .IsRequired()
               .HasMaxLength(11);

        builder.HasIndex(s => s.Cpf)
               .IsUnique();
    }
}
