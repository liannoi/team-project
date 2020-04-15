using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamProject.Persistence.Configurations.Film
{
    public class FilmConfiguration : IEntityTypeConfiguration<Domain.Entities.Film.Film>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Film.Film> builder)
        {
            builder.HasKey(e => e.FilmId);
            builder.HasIndex(e => e.Title).HasName("UNQ_Films_Title").IsUnique();
            builder.Property(e => e.Description).HasMaxLength(4000);
            builder.Property(e => e.PublishYear).HasColumnType("date");
            builder.Property(e => e.Title).IsRequired().HasMaxLength(128);
        }
    }
}