using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class MarcacaoMapping : IEntityTypeConfiguration<Marcacao>
    {
        public void Configure(EntityTypeBuilder<Marcacao> builder)
        {
            builder.ToTable("MARCACOES");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.DataHora)
                .IsRequired();

            builder.Property(prop => prop.Descricao)
                .IsRequired(false);
        }
    }
}