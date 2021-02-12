using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Laboratorio1.Models;
using Laboratorio1.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web;


namespace Laboratorio1.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IFormCollection collection) //Create list C# linkedlist
        {
            try
            {
                var NewPlayer = new Models.Jugador
                {
                    Name = collection["Name"],
                    Surname = collection["Surname"],
                    Salary = Convert.ToDouble(collection["Salary"]),
                    Position = collection["Position"],
                    Club = collection["Club"]
                };
                Singletton.Instance.PlayerList.AddLast(NewPlayer);
                return View();

            }
            catch
            {
                return View();
            }
        }
        public IActionResult CreateGeneric()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGeneric(IFormCollection collection) //Create DobleList
        {
                return View();
            
        }
            public IActionResult FileCSV()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FileCSV(List<IFormFile> Files) // File CSV
        {
            string filepath = string.Empty;
            if (Files!=null)
            {
                
            }
            return RedirectToAction(nameof(Create));
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ListPlayer() //Player List c#
        {
            return View(Singletton.Instance.PlayerList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
