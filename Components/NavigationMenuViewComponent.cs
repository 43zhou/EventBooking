using System.Linq;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Components
{
    public class NavigationMenuViewComponent :  ViewComponent
    {
        private ICreatedEventRepository repository;
        public NavigationMenuViewComponent(ICreatedEventRepository repo)
        {
            repository=repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.CreatedEvents
                .Select(x=>x.Category)
                .Distinct()
                .OrderBy(x=>x));
        }
    }
}