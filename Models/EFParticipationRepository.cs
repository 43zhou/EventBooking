using System;
using System.Collections.Generic;
using System.Linq;

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

        public void SaveEvent(Participation participation)
        {
            //throw new NotImplementedException();
            if (participation.ID == 0 && participation != null)
            {
                context.Participations.Add(participation);
            }
            else
            {
                Participation dbEntry = context.Participations
                    .FirstOrDefault(p=>p.ID==participation.ID);
                if(dbEntry!=null)
                {
                    dbEntry.CreatedEvent=participation.CreatedEvent;
                    dbEntry.StudentNumber=participation.StudentNumber;
                    dbEntry.Title=participation.Title;
                    dbEntry.Username=participation.Username;
                }
            }
            context.SaveChanges();
        }
    }
}