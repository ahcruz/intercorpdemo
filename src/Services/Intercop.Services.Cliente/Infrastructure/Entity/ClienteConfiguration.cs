using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intercop.Services.Cliente.Infrastructure.Entity
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Domain.Cliente>
    {
        public void Configure(EntityTypeBuilder<Domain.Cliente> builder)
        {
            builder.ToTable("Clientes");
            // set Id como primaryKey
            builder.HasKey(c => c.ClienteId);
        }
    }
}