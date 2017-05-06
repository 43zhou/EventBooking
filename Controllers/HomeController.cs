using System;
using System.Linq;
using System.Security.Claims;
using EventBookingSystem.Models;
using EventBookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ICreatedEventRepository repository;
        private IParticipationRepository p_rope;
        // private UserManager<IdentityUser> _userManager;
        public int PageSize=4;
        public HomeController(ICreatedEventRepository repo, IParticipationRepository repo_p)
        {
            repository = repo;
            p_rope = repo_p;
            // _userManager=userMgr;
           
        }
        
        [AllowAnonymous]
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
        [Authorize]
        public RedirectToActionResult Join(){
            TempData["message"]="f";
            return RedirectToAction("Index");
        }

        [HttpPost] 
        [Authorize]
        public RedirectToActionResult Join(CreatedEvent ce)
        {
            var entity = repository.CreatedEvents
                .Where(e=>e.ID==ce.ID)
                .FirstOrDefault();
            if(entity != null)
            {
                if(p_rope.participations.Where(p=>p.CreatedEvent==entity)
                                        .Where(c=>c.Username==User.Identity.Name).Count()==0)
                {
                    var participate = new Participation(){
                        CreatedEvent=entity,
                        Title=entity.Title,
                        StudentNumber=User.Identity.Name,
                        Username=User.Identity.Name
                    };
                    p_rope.SaveEvent(participate);
                    var dbEntity= repository.CreatedEvents.Where(e=>e.ID==ce.ID).FirstOrDefault();
                    dbEntity.CountOfParticipation+=1;
                    repository.SaveEvent(dbEntity);                  
                }
                else
                {
                    // ViewBag.Message = string.Format("You have joined this activity!");
                    TempData["message"]="You have joined this activity!";
                    TempData["ID"]=entity.ID.ToString();
                }
            }
            return RedirectToAction("Index");
        }
    }
}