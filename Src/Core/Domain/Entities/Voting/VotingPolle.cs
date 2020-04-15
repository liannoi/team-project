using System.Collections.Generic;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Domain.Entities.Voting
{
    public class VotingPolle
    {
        public VotingPolle()
        {
            VotingPolles = new HashSet<VotingPolleRelation>();
        }

        public int VotingPolleId { get; set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public ICollection<VotingPolleRelation> VotingPolles { get; private set; }
    }
}