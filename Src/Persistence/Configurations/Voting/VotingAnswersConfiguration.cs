using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamProject.Domain.Entities.Voting;

namespace TeamProject.Persistence.Configurations.Voting
{
    public class VotingAnswersConfiguration : IEntityTypeConfiguration<VotingAnswer>
    {
        public void Configure(EntityTypeBuilder<VotingAnswer> builder)
        {
            builder.HasKey(e => e.VotingAnswerId);

            builder.Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(512);

            builder.HasOne(d => d.Voting)
                .WithMany(p => p.VotingAnswers)
                .HasForeignKey(d => d.VotingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VotingAnswers_VotingId");
        }
    }
}