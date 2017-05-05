using System;
using System.Linq;
using EventBookingSystem.Models;
using EventBookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private ICreatedEventRepository repository;
        public int PageSize=4;
        public HomeController(ICreatedEventRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string category, int page=1)
        {
            return View(new EventListViewModel{
                CreatedEvents=repository.CreatedEvents
                    .Where(c=>category==null || c.Category==category)
                    .OrderBy(e=>e.ID)
                    .Skip((page-1)*PageSize)
                    .Take(PageSize),
                PagingInfo=new PagingInfo
                {
                    CurrentPage=page,
                    ItemsPerPage=PageSize,
                    TotalItems= category ==null?
                        repository.CreatedEvents.Count():
                        repository.CreatedEvents.Where(e=>e.Category==category).Count()
                },
                CurrentCategory=category

            });
        }
    }
}