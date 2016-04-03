using FizzBuzzTest.Services;
using FizzBuzzTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzBuzzTest.Controllers
{
    public class HomeController : Controller
    {      
        private const int itemsPerPage = 20;

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //POST: Home
        public ActionResult Index(string submitButton, FizzBuzzViewModel model)
        {
            if (!ModelState.IsValid || model.Input < 1 || model.Input > 100)
                return View();

            FizzBuzzService fizzBuzzService = new FizzBuzzService();
      
            if (model.Section == null)
                model.Section = 0;
           
            int initialSection = (int)model.Section;
            ModelState.Clear();
            if (submitButton == "previous")
                model.Section = model.Section == 0 ? 0 : initialSection - 1;
            else if (submitButton == "next")
                model.Section = (model.Section + 1) * itemsPerPage >= model.Input ? initialSection : initialSection + 1;
            else if (submitButton == "submit")
                model.Section = 0;

            int numberOfItemsToDisplay = Math.Min(model.Input - (int)model.Section * itemsPerPage, itemsPerPage);
            model.Sequence = fizzBuzzService.FizzBuzzSequence(model.Input, DateTimeOffset.Now.DayOfWeek == DayOfWeek.Wednesday).Skip(itemsPerPage * (int)model.Section).Take(numberOfItemsToDisplay).ToList();

            return View(model);
        }
    }
}