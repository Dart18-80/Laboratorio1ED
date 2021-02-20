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
using Microsoft.AspNetCore.Hosting;


namespace Laboratorio1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(ILogger<HomeController> logger,
                              IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.hostingEnvironment = hostingEnvironment;
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
                    Id = Convert.ToInt32(Jugador.cont++)
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
                    Club = collection["Club"],
                    Id = Convert.ToInt32(Jugador.cont++)
                };
                Singletton.Instance.listaJugador.AddHead(NewPlayerGeneric);
                return View();
            }
            catch
            {
                return View();
            }

        }
        public IActionResult UploadFilecsv()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFilecsv(Jugador model)
        {
            string uniqueFileName = null;
            if (model.FileC != null)
            {
                string uploadsfolder= Path.Combine(hostingEnvironment.WebRootPath, "Upload");
                uniqueFileName=model.FileC.FileName;
                string filepath=Path.Combine(uploadsfolder, uniqueFileName);
                if (!System.IO.File.Exists(filepath))
                {
                    using (var iNeedToLearnAboutDispose = new FileStream(filepath, FileMode.CreateNew))
                    {
                        model.FileC.CopyTo(iNeedToLearnAboutDispose);
                    }
                }
                    string ccc = System.IO.File.ReadAllText(filepath);
                    foreach (string row in ccc.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (row.Split(',')[0]!="club")
                            {
                                Singletton.Instance.PlayerList.AddLast(new Jugador
                                {
                                    Club = row.Split(',')[0],
                                    Surname = row.Split(',')[1],
                                    Name = row.Split(',')[2],
                                    Position = row.Split(',')[3],
                                    Salary = Convert.ToDouble(row.Split(',')[4]),
                                    Id = Convert.ToInt32(Jugador.cont++)
                                });
                            }
                          
                        }
                    }
                    return RedirectToAction("ListPlayer");
            }
            return View();
        }
        public IActionResult UploadFilecsvGeneric()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFilecsvGeneric(Jugador model)
        {
            string uniqueFileName = null;
            if (model.FileC != null)
            {
                string uploadsfolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload");
                uniqueFileName = model.FileC.FileName;
                string filepath = Path.Combine(uploadsfolder, uniqueFileName);
                if (!System.IO.File.Exists(filepath))
                {
                    using (var iNeedToLearnAboutDispose = new FileStream(filepath, FileMode.CreateNew))
                    {
                        model.FileC.CopyTo(iNeedToLearnAboutDispose);
                    }
                }
                string ccc = System.IO.File.ReadAllText(filepath);
                foreach (string row in ccc.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (row.Split(',')[0] != "club")
                        {
                            Singletton.Instance.listaJugador.AddHead(new Jugador
                            {
                                Club = row.Split(',')[0],
                                Surname = row.Split(',')[1],
                                Name = row.Split(',')[2],
                                Position = row.Split(',')[3],
                                Salary = Convert.ToDouble(row.Split(',')[4]),
                                Id = Convert.ToInt32(Jugador.cont++)
                            });
                        }

                    }
                }
                return RedirectToAction("ListPlayerGeneric");
            }
            return View();

        }
        
        public IActionResult Privacy()
        {
            return View();
        }
    
        public async Task<IActionResult> ListPlayer( string Check, double SSalary,  string SSearch, string SType) //Player List c#
        {
            ViewData["CurrentFilterType"] = SType;
            ViewData["CurrentFilterSearch"] = SSearch;
            ViewData["CurrentFilterSalary"] = SSalary;
            ViewData["CurrentFilterCheck"] = Check;
            Singletton.Instance.Search.Clear();
            switch (SType)
            {
                case "Name":
                    for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                    {
                        if (Singletton.Instance.PlayerList.ElementAt(i).Name == SSearch)
                        {
                            Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                        }
                    }
                    return View(Singletton.Instance.Search);

                case "Surname":
                    for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                    {
                        if (Singletton.Instance.PlayerList.ElementAt(i).Surname == SSearch)
                        {
                            Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                        }
                    }
                    return View(Singletton.Instance.Search);

                case "Club":
                    for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                    {
                        if (Singletton.Instance.PlayerList.ElementAt(i).Club == SSearch)
                        {
                            Singletton.Instance.Search.AddLast(Singletton.Instance.PlayerList.ElementAt(i));
                        }
                    }
                    return View(Singletton.Instance.Search);

                case "Position":
                    for (int i = 0; i < Singletton.Instance.PlayerList.Count; i++)
                    {
                        if (Singletton.Instance.PlayerList.ElementAt(i).Position == SSearch)
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
        Jugador LlamadoClass = new Jugador();
        delegate int Delagados(Jugador Jug, string jug1);
        public IActionResult ListPlayerGeneric(string Check, double SSalary, string SSearch, string SType) //Player List Generic
        {
            ViewData["CurrentFilterType"] = SType;
            ViewData["CurrentFilterSearch"] = SSearch;
            ViewData["CurrentFilterSalary"] = SSalary;
            ViewData["CurrentFilterCheck"] = Check;
            switch (SType)
            {
                case "Name":
                    Delagados InvocarNombre = new Delagados(LlamadoClass.CompareByName);
                    return View(Singletton.Instance.listaJugador.Buscar(Singletton.Instance.listaJugador.Header, SSearch, InvocarNombre));

                case "Surname":
                    Delagados InvocarApellido = new Delagados(LlamadoClass.CompareBySurname);
                    return View(Singletton.Instance.listaJugador.Buscar(Singletton.Instance.listaJugador.Header, SSearch, InvocarApellido));

                case "Club":
                    Delagados InvocarClub = new Delagados(LlamadoClass.CompareByClub);
                    return View(Singletton.Instance.listaJugador.Buscar(Singletton.Instance.listaJugador.Header, SSearch, InvocarClub));

                case "Position":
                    Delagados InvocarPosicion = new Delagados(LlamadoClass.CompareByPosition);
                    return View(Singletton.Instance.listaJugador.Buscar(Singletton.Instance.listaJugador.Header, SSearch, InvocarPosicion));
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

            Singletton.Instance.Procedimiento.Mostrar(Singletton.Instance.listaJugador.Header, Singletton.Instance.Nueva);
            return View(Singletton.Instance.Nueva);
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
        public IActionResult EditGeneric(int idgen)
        {
            var EditPlayer = Singletton.Instance.PlayerList.FirstOrDefault(x => x.Id == idgen);
            return View(EditPlayer);
        }
        [HttpPost]
        public IActionResult EditGeneric(int idgen, IFormCollection collection)
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
                    Id = Convert.ToInt32(idgen)
                };
                return View();
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
