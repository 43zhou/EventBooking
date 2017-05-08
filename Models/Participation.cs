namespace EventBookingSystem.Models
{
    public class Participation
    {
        public int ID{get;set;}
        public int CreatedEventID{get;set;}
        public string Title{get;set;}
        public string Username{get;set;}
        public string StudentNumber{get;set;}

        public CreatedEvent CreatedEvent{get;set;}
    }
}