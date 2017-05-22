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
                    .Where(p=>p.ID==participation.ID)
                    .FirstOrDefault();
                if(dbEntry!=null)
                {
                    dbEntry.StudentNumber=participation.StudentNumber;
                    dbEntry.Title=participation.Title;
                    dbEntry.Username=participation.Username;
                    dbEntry.CreatedEventID=participation.CreatedEventID;
                    dbEntry.Date=participation.Date;
                    dbEntry.Location=participation.Location;
                }
            }
            context.SaveChanges();
        }

        public Participation DeleteParticipatedEvent(int participatedEventID)
        {
            Participation dbEntry=context.Participations.Where(p=>p.ID==participatedEventID)
                    .FirstOrDefault();
            if(dbEntry!=null)
            {
                context.Participations.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}