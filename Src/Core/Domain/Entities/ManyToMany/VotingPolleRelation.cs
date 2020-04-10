﻿using TeamProject.Domain.Entities.Voting;

namespace TeamProject.Domain.Entities.ManyToMany
{
    public class VotingPolleRelation
    {
        public int VotingPolleId { get; set; }
        public int VotingId { get; set; }
        public int PolleId { get; set; }
        public int VotingAnswerId { get; set; }

        public VotingPolle Polle { get; set; }
        public Voting.Voting Voting { get; set; }
        public VotingAnswer VotingAnswer { get; set; }
    }
}