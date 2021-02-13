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
using LibreriaClases;


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
        public IActionResult Create(IFormCollection collection) //  Crear lista c#
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
        public IActionResult CreateGeneric(IFormCollection collection)
        {
            DoubleList<Jugador> Nueva = new DoubleList<Jugador>(); //LLamado a los procedimientos de DoubleList
            try
            {
                var NewPlayerGeneric = new Models.Jugador
                {
                    Name = collection["Name"],
                    Surname = collection["Surname"],
                    Salary = Convert.ToDouble(collection["Salary"]),
                    Position = collection["Position"],
                    Club = collection["Club"]
                };
                Nueva.Insert(NewPlayerGeneric, Nueva);
                return View();

            }
            catch
            {
                return View();
            }

        }
        public IActionResult FileCSV()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> FileCSV(IFormFile postedfile) // File CSV
        {
            string filepath = string.Empty;
            if (postedfile != null)
            {
                string path = Path.Combine("~/Upload/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filepath = path + Path.GetFileName(postedfile.FileName);
                string extension = Path.GetExtension(postedfile.FileName);

                string CsvData = System.IO.File.ReadAllText(filepath);
                foreach (string row in CsvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        Singletton.Instance.PlayerList.AddLast(new Jugador { 
                        Club=row.Split(',')[0],
                        Surname= row.Split(',')[1],
                        Name = row.Split(',')[2],
                        Position=row.Split(',')[3],
                        Salary=Convert.ToDouble(row.Split(',')[4])
                        });
                    }
                }
            }
            return RedirectToAction(nameof(ListPlayer));
        }
        public IActionResult Privacy()
        {
            return View();
        }
    
        public async Task<IActionResult> ListPlayer(string searchstring) //Player List c#
        {
            
            ViewData["CurrentFilter"] = searchstring;
      
            return View(Singletton.Instance.PlayerList);
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
