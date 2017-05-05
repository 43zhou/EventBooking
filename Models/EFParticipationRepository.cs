using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models
{
    public class EFParticipationRepository : IParticipationRepository
    {
        private ApplicationDbContext context; 
        public EFParticipationRepository(ApplicationDbContext ctx) 
        { 
            context = ctx; 
        }
        public IEnumerable<Participation> participations => context.Participations;

        public void SaveOrder(Participation participation)
        {
            throw new NotImplementedException();
        }
    }
}