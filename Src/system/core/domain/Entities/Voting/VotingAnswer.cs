﻿using System.Collections.Generic;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Domain.Entities.Voting
{
    public class VotingAnswer
    {
        public VotingAnswer()
        {
            VotingPolles = new HashSet<VotingPolleRelation>();
        }

        public int VotingAnswerId { get; set; }
        public int VotingId { get; set; }
        public string Text { get; set; }

        public Voting Voting { get; set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public ICollection<VotingPolleRelation> VotingPolles { get; private set; }
    }
}