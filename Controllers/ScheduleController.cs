using System;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using playgroud_asp_schedule.Models;

namespace playgroud_asp_schedule.Controllers
{
        
    public class ScheduleController : Controller
    {
        
        private SchedulingContext db = new SchedulingContext();
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            var schedule_event = db.Event;
            return View(schedule_event);
        }

        public IActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.User, "user_id", "name");
            ViewBag.location_id = new SelectList(db.Location, "location_id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event model)
        {
			if (ModelState.IsValid) {   
                db.Event.Add(new Event {
                    user_id = model.user_id,
                    location_id = model.location_id,
                    start = model.start, 
                    stop = model.stop
                });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
				return RedirectToAction("Index");
			}

            return View(model);
        }


    }
}
