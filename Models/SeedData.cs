using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EventBookingSystem.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app) 
        { 
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>(); 
            if(!context.CreatedEvents.Any())
            {
                context.CreatedEvents.AddRange(
                    new CreatedEvent{
                        Username = "Zhou",
                        StudentNameber="5382361",
                        Title="Basketball game",
                        Price=2,
                        Date=new DateTime(2017,5,28),
                        PromotionalCode="001",
                        Capacities=300,
                        Category="Sport"
                    },
                    new CreatedEvent{
                        Username = "Zhou",
                        StudentNameber="5382361",
                        Title="Video game",
                        Price=20,
                        Date=new DateTime(2017,6,30),
                        PromotionalCode="002",
                        Capacities=20,
                        Category="Gaming"
                    },
                    new CreatedEvent{
                        Username = "Zhou",
                        StudentNameber="5382361",
                        Title="Socor game",
                        Price=2,
                        Date=new DateTime(2017,7,28),
                        PromotionalCode="003",
                        Capacities=200,
                        Category="Sport"
                    },
                    new CreatedEvent{
                        Username = "Zhou",
                        StudentNameber="5382361",
                        Title="Swimming game",
                        Price=2,
                        Date=new DateTime(2017,10,2),
                        PromotionalCode="004",
                        Capacities=300,
                        Category="Sport"
                    },
                    new CreatedEvent{
                        Username = "Zhou",
                        StudentNameber="5382361",
                        Title="Running game",
                        Price=2,
                        Date=new DateTime(2017,11,28),
                        PromotionalCode="005",
                        Capacities=3000,
                        Category="Sport"
                    },
                    new CreatedEvent{
                        Username = "Zhou",
                        StudentNameber="5382361",
                        Title="Singing",
                        Price=2,
                        Date=new DateTime(2017,5,29),
                        PromotionalCode="006",
                        Capacities=300,
                        Category="Show"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}