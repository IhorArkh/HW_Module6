using HW_6_2_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace HW_6_2_website.Controllers
{
    public class PeopleController : Controller
    {
        public static List<Human> People = new List<Human>();

        public async Task<IActionResult> IndexAsync()
        {
            People = new List<Human>();
            var client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:57275/");

            var response = await client.GetAsync("people");
            var jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var people = JsonSerializer.Deserialize<List<Human>>(jsonString, options);

            foreach (var human in people)
            {
                People.Add(human);
            }

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

            if (human!= null)
            {
                var client = new HttpClient();
                client.BaseAddress = new System.Uri("https://localhost:57275/people/");
                var response = client.DeleteAsync($"{client.BaseAddress}{human.Passport}").Result;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ReadAsync(int passport)
        {
            var human = People.FirstOrDefault(h => h.Passport == passport);
            var client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:57275/people/");
            var response = await client.GetAsync($"{human.Passport}");
            var jsonString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var newHuman = JsonSerializer.Deserialize<Human>(jsonString, options);

            return View(newHuman);
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
            if (human != null)
            {
                var client = new HttpClient();
                client.BaseAddress = new System.Uri("https://localhost:57275/people/");
                var humanJson = JsonSerializer.Serialize(human);
                var response = client.PutAsync
                    ($"{human.Passport}", new StringContent(humanJson, Encoding.UTF8, "application/json")).Result;
            }

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
            var client = new HttpClient();
            var humanJson = JsonSerializer.Serialize(human);
            var response = client.PostAsync("https://localhost:57275/people", new StringContent(humanJson, Encoding.UTF8, "application/json")).Result;

            return RedirectToAction("Index");
        }
    }
}