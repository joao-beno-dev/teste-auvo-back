using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOAS");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}