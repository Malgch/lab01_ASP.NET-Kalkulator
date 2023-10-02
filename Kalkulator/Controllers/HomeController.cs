using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Jan";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry" : "Dobry wieczor";

            Dane[] osoby =
            {
                new Dane {Name = "Jan", Surname = "Kowalski"},
                new Dane {Name = "Anna", Surname = "Maria"},
                new Dane {Name = "Krzysztof", Surname = "Nowak"}
            };

            return View(osoby);
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie}, masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult Calculator(Models.Calculator input)
        {
            if (input.ZnakDzialania == "+")
            {
                input.Wynik = input.PierwszaLiczba + input.DrugaLiczba;
            }
            else if (input.ZnakDzialania == "-")
            {
                input.Wynik = input.PierwszaLiczba - input.DrugaLiczba;
            }
            else if (input.ZnakDzialania == "/")
            {
                input.Wynik = input.PierwszaLiczba / input.DrugaLiczba;
            }
            else if (input.ZnakDzialania == "*")
            {
                input.Wynik = input.PierwszaLiczba * input.DrugaLiczba;
            }
            else
            {
                ViewBag.wynik = "Podaj poprawny znak działania oraz liczby";
                return View();
            }
            ViewBag.wynik = $"Wynik działania {input.PierwszaLiczba} {input.ZnakDzialania} {input.DrugaLiczba} wynosi {input.Wynik}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}