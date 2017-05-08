using System;
using System.Linq;
using EventBookingSystem.Models;
using EventBookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ICreatedEventRepository ceRepository;
        private IParticipationRepository pRepository;
        public UserController(ICreatedEventRepository cRepo, IParticipationRepository pRepo)
        {
            ceRepository=cRepo;
            pRepository=pRepo;
        }

        public ViewResult CreatedEvents(string category)
        {
            return View(new EventListViewModel{
                CreatedEvents=ceRepository.CreatedEvents
                    .Where(c=>c.StudentNameber==User.Identity.Name)
                    .OrderBy(e=>e.ID)
            });
        }

        public ViewResult Edit(int id) =>
            View(ceRepository.CreatedEvents 
                .FirstOrDefault(p => p.ID == id));

        [HttpPost] 
        public IActionResult Edit(CreatedEvent e) 
        { 
            e.StudentNameber=User.Identity.Name;
            e.Username=User.Identity.Name;
            e.CountOfParticipation=e.CountOfParticipation;
            Convert.ToDateTime(e.Date);
            if (ModelState.IsValid) 
            {   
                ceRepository.SaveEvent(e); 
                // Session
                TempData["message"] = $"{e.Title} has been saved"; 
                return RedirectToAction("CreatedEvents"); 
            } 
            else 
            { 
                var erros=ModelState.Values.SelectMany(v => v.Errors);
                // TempData["message"]= erros.FirstOrDefault().ErrorMessage + " "+ erros.Last().ErrorMessage;
                // there is something wrong with the data values 
                return View(e); 
            }
        }

        public ViewResult Create() => View("Edit", new CreatedEvent());
        [HttpPost] 
        public IActionResult Delete(int id) 
        { 
            CreatedEvent deletedProduct = ceRepository.DeleteCrCreatedEvent(id); 
            if (deletedProduct != null) 
            { 
                TempData["message"] = $"{deletedProduct.Title} was deleted"; 
            } 
            return RedirectToAction("CreatedEvents"); 
        }

        public ViewResult Participated()
        {
            return View(new EventListViewModel{
                Participations=pRepository.participations
                    .Where(c=>c.Username==User.Identity.Name)
                    .OrderBy(e=>e.ID)
            });
        }
        [HttpPost]
        public IActionResult Cancel(int id) 
        { 
            Participation deletedEvet = pRepository.DeleteParticipatedEvent(id); 
            if (deletedEvet != null) 
            { 
                var dbEntry=ceRepository.CreatedEvents.Where(c=>c.ID==deletedEvet.CreatedEventID).FirstOrDefault();
                dbEntry.CountOfParticipation-=1;
                ceRepository.SaveEvent(dbEntry);
                // TempData["message"] = $"{deletedProduct.Title} was deleted"; 
            } 
            return RedirectToAction("Participated"); 
        }
    }
}