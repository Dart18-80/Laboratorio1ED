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
using MLSClassLibrary;
using Microsoft.AspNetCore.Hosting;


namespace Laboratorio1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment hostingEnvironment1;
        public HomeController(ILogger<HomeController> logger,
                              IHostingEnvironment hostingEnvironment)
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
                    Club = collection["Club"],
                    Id = Convert.ToInt32(Jugador.cont++),
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
                return View();

            }
            catch
            {
                return View();
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }
    
        public async Task<IActionResult> ListPlayer(string SName, string Check, double SSalary, string SSour, string SPosition, string SClub) //Player List c#
        {
            
            ViewData["CurrentFilterName"] = SName;
            ViewData["CurrentFilterSuor"] = SSour;
            ViewData["CurrentFilterPosition"] = SPosition;
            ViewData["CurrentFilterClub"] = SClub;
            ViewData["CurrentFilterSalary"] = SSalary;
            ViewData["CurrentFilterCheck"] = Check;
            Singletton.Instance.Search.Clear();

            if (SSour!=null)
            {
                for (int i = 0; i < Singletton.Instance.PlayerList.Count ; i++)
                {
                    if (Singletton.Instance.PlayerList.ElementAt(i).Surname == SSour)
                    {
                        Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                    }
                }
                return View(Singletton.Instance.Search);
            }

            if (SName != null)
            {
                for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                {
                    if (Singletton.Instance.PlayerList.ElementAt(i).Name == SName)
                    {
                        Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                    }
                }
                return View(Singletton.Instance.Search);
            }

            if (SClub != null)
            {
                for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                {
                    if (Singletton.Instance.PlayerList.ElementAt(i).Club == SClub)
                    {
                        Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                    }
                }
                return View(Singletton.Instance.Search);
            }

            if (SPosition != null)
            {
                for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                {
                    if (Singletton.Instance.PlayerList.ElementAt(i).Position == SPosition)
                    {
                        Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                    }
                }
                return View(Singletton.Instance.Search);
            }

            switch (Check)
            {
                case "Less":
                    for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                    {
                        if (Singletton.Instance.PlayerList.ElementAt(i).Salary < SSalary)
                        {
                            Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                        }
                    }
                    return View(Singletton.Instance.Search);

                case "Equal":
                    for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                    {
                        if (Singletton.Instance.PlayerList.ElementAt(i).Salary == SSalary)
                        {
                            Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                        }
                    }
                    return View(Singletton.Instance.Search);

                case "More":
                    for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                    {
                        if (Singletton.Instance.PlayerList.ElementAt(i).Salary > SSalary)
                        {
                            Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                        }
                    }
                    return View(Singletton.Instance.Search);
            }
            return View(Singletton.Instance.PlayerList);

        }
        public IActionResult Edit(int id)
        {
            var EditPlayer = Singletton.Instance.PlayerList.FirstOrDefault(x => x.Id == id);
            return View(EditPlayer);
        }
        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var NewPlayerEdit = new Models.Jugador
                {
                    Name = collection["Name"],
                    Surname = collection["Surname"],
                    Salary = Convert.ToDouble(collection["Salary"]),
                    Position = collection["Position"],
                    Club = collection["Club"],
                    Id = Convert.ToInt32(id)
                };
                Singletton.Instance.PlayerList.Remove(Singletton.Instance.PlayerList.FirstOrDefault(x => x.Id == id));
                Singletton.Instance.PlayerList.AddFirst(NewPlayerEdit);
                return RedirectToAction("ListPlayer");
            }
            catch (Exception)
            {
                return View();
            }           
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
