using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamProject.Persistence.Configurations.Voting
{
    public class VotingConfiguration : IEntityTypeConfiguration<Domain.Entities.Voting.Voting>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Voting.Voting> builder)
        {
            builder.HasIndex(e => e.Name)
                .HasName("UNQ_Voting_Name")
                .IsUnique();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}