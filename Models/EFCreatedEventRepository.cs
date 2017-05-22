using System;
using System.Collections.Generic;
using System.Linq;

namespace EventBookingSystem.Models
{
    public class EFCreatedEventRepository : ICreatedEventRepository
    {
        private ApplicationDbContext context;

        public EFCreatedEventRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<CreatedEvent> CreatedEvents => context.CreatedEvents;

        public CreatedEvent DeleteCrCreatedEvent(int createdEventID)
        {
            // throw new NotImplementedException();
            CreatedEvent dbEntry=context.CreatedEvents
                    .FirstOrDefault(p=>p.ID==createdEventID);
            if(dbEntry!=null)
            {
                context.CreatedEvents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveEvent(CreatedEvent createdEvent)
        {
            // throw new NotImplementedException();
            if (createdEvent.ID==0)
            {
                context.CreatedEvents.Add(createdEvent);
            }
            else
            {
                CreatedEvent dbEntry=context.CreatedEvents
                    .FirstOrDefault(p=>p.ID==createdEvent.ID);
                if(dbEntry!= null)
                {
                    dbEntry.Title=createdEvent.Title;
                    dbEntry.Date=createdEvent.Date;
                    dbEntry.Capacities=createdEvent.Capacities;
                    dbEntry.Price=createdEvent.Price;
                    dbEntry.PromotionalCode=createdEvent.PromotionalCode;
                    dbEntry.StudentNameber=createdEvent.StudentNameber;
                    dbEntry.Username=createdEvent.Username;
                    dbEntry.Category=createdEvent.Category;
                    dbEntry.Location=createdEvent.Location;
                }
            }
            context.SaveChanges();
        }
    }
}