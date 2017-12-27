using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelMedium.Web.Models;
using System.Data.SqlClient;


//kefe lozis me ko malo dijete
namespace HotelMedium.Web.Controllers
{
    public class HomeController : Controller
    {

        private HotelContext _context;

        public HomeController(HotelContext home) //dependencies injection
        {
            _context = home;
        }

        public IActionResult Index()
        {
            List<Countries> lista = _context.Countries.ToList();
            ViewBag.CountriesLista = lista;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
