using System;

namespace EventBookingSystem.Models
{
    public class CreatedEvent
    {
        public int ID{get;set;}
        public string Username{get;set;}
        public string StudentNameber{get;set;}
        public string Title{get;set;}
        public decimal Price{get;set;}
        public DateTime Date{get;set;}
        public string PromotionalCode{get;set;}
        public int Capacities{get;set;}
        public string Category{get;set;}
        
    }
}