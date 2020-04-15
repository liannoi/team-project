using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamProject.Domain.Entities;

namespace TeamProject.Persistence.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(e => e.LogId);
            builder.Property(e => e.Application).IsRequired().HasMaxLength(64);
            builder.Property(e => e.Time).IsRequired();
            builder.Property(e => e.Level).IsRequired().HasMaxLength(64);
            builder.Property(e => e.Message).IsRequired().HasMaxLength(512);
            builder.Property(e => e.Service).IsRequired(false).HasMaxLength(512);
            builder.Property(e => e.Exception).IsRequired(false).HasMaxLength(512);
            builder.Property(e => e.Callsite).IsRequired(false).HasMaxLength(512);
        }
    }
}