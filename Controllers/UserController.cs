using System;
using Microsoft.AspNet.Mvc;
using playgroud_asp_schedule.Models;

namespace playgroud_asp_schedule.Controllers
{

    public class UserController : Controller
    {
        private SchedulingContext db = new SchedulingContext();
        
        public IActionResult Index()
        {
            var users = db.User;
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User model)
        {
            
			if (ModelState.IsValid) {   
                db.User.Add(new User {name = model.name});
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