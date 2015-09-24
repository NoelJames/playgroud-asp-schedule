using System;
using Microsoft.AspNet.Mvc;
using playgroud_asp_schedule.Models;

namespace playgroud_asp_schedule.Controllers
{

    public class LocationController : Controller
    {
        private SchedulingContext db = new SchedulingContext();
        
        public IActionResult Index()
        {
            var location = db.Location;
            return View(location);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Location model)
        {
            
			if (ModelState.IsValid) {   
                db.Location.Add(new Location {name = model.name});
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
				return RedirectToAction("Index");
			}
            else{
                Console.WriteLine("Not ModelState.IsValid");
            }

            return View(model);
        }

    }


}