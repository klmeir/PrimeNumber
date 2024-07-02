using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeNumber.Domain.Entities;

namespace PrimeNumber.Infrastructure.DataSource.ModelConfig
{
    public class PrimeNumberRequestLogConfig : IEntityTypeConfiguration<PrimeNumberRequestLog>
    {        
        public void Configure(EntityTypeBuilder<PrimeNumberRequestLog> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Request).IsRequired();
            builder.Property(b => b.DateRequest).IsRequired();
            builder.Property(b => b.Response).IsRequired();
            builder.Property(b => b.DateResponse).IsRequired();
            builder.Property(b => b.User).IsRequired();
        }
    }
}
