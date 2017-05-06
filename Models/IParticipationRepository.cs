using System.Collections.Generic;

namespace EventBookingSystem.Models
{
    public interface IParticipationRepository
    {
         IEnumerable<Participation> participations{get;}
         void SaveEvent(Participation participation); 
    }
}