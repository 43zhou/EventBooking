using System.Collections.Generic;

namespace EventBookingSystem.Models.ViewModels
{
    public class EventListViewModel
    {
        public IEnumerable<CreatedEvent> CreatedEvents{get;set;}
        public PagingInfo PagingInfo{get;set;}   
        public string CurrentCategory{get;set;}
        public IEnumerable<Participation> Participations{get;set;}
    }
}