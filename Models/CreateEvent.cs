using System;
using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class CreatedEvent
    {
        public int ID{get;set;}  
        public string Username{get;set;}
        public string StudentNameber{get;set;}
        [Required(ErrorMessage = "Please enter a Title")]
        public string Title{get;set;}
        [Required(ErrorMessage = "Please enter a Price")]
        public decimal Price{get;set;}
        [Required(ErrorMessage = "Please enter a Date")]
        public DateTime Date{get;set;}
        [Required(ErrorMessage = "Please enter a PromotionalCode")]
        public string PromotionalCode{get;set;}
        [Required(ErrorMessage = "Please enter a Capacities")]
        public int Capacities{get;set;}
        [Required(ErrorMessage = "Please enter a Category")]
        public string Category{get;set;}
        public int CountOfParticipation{get;set;} = 0;
        
    }
}