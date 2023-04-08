using HW_6_2_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW_6_2_website.Controllers
{
    public class PeopleController : Controller
    {
        public static List<Human> People = new List<Human>()
        {
            new Human(){ Passport = 981166, Name = "Adam", Age = 12},
            new Human(){ Passport = 981167, Name = "John", Age = 14},
            new Human(){ Passport = 981168, Name = "Sally", Age = 13},
            new Human(){ Passport = 981169, Name = "Eva", Age = 15}
        };

        public IActionResult Index()
        {
            return View(People);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult Delete(int passport)
        {
            var human = People.FirstOrDefault(h => h.Passport == passport);

            return View(human);
        }

        [HttpPost]
        public ActionResult Delete2(int passport)
        {
            var human = People.FirstOrDefault(h => h.Passport == passport);

            var x = People.Remove(human);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Read(int passport)
        {
            var human = People.FirstOrDefault(h => h.Passport == passport);

            return View(human);
        }

        [HttpGet]
        public ActionResult Update(int passport)
        {
            var human = People.FirstOrDefault(h => h.Passport == passport);

            return View(human);
        }

        [HttpPost]
        public ActionResult Update(Human human)
        {
            var currHuman = People.FirstOrDefault(h => h.Passport == human.Passport);

            currHuman.Name = human.Name;
            currHuman.Age = human.Age;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Human human)
        {
            People.Add(human);
            return RedirectToAction("Index");
        }
    }
}