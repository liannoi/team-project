using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamProject.Persistence.Configurations.Actor
{
    public class ActorConfiguration : IEntityTypeConfiguration<Domain.Entities.Actor.Actor>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Actor.Actor> builder)
        {
            builder.HasKey(e => e.ActorId);
            builder.Property(e => e.Birthday).HasColumnType("date");
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(54);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(54);
        }
    }
}