using System.Collections.Generic;

namespace EventBookingSystem.Models
{
    public interface ICreatedEventRepository
    {
         IEnumerable<CreatedEvent> CreatedEvents{get;}
         void SaveEvent(CreatedEvent createdEvent);
         CreatedEvent DeleteCrCreatedEvent(int createdEventID);
    }
}