using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamProject.Domain.Entities.Voting;

namespace TeamProject.Persistence.Configurations.Voting
{
    public class VotingPolleConfiguration : IEntityTypeConfiguration<VotingPolle>
    {
        public void Configure(EntityTypeBuilder<VotingPolle> builder)
        {
            builder.Property(e => e.VotingPolleId).ValueGeneratedNever();
        }
    }
}