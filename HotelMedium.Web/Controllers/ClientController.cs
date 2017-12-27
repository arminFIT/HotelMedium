using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelMedium.Web.Models.ClientViewModels;
using HotelMedium.Web.Models;

namespace HotelMedium.Web.Controllers
{
    public class ClientController : Controller
    {

        private HotelContext _hotelContext;

        public ClientController(HotelContext context)
        {
            _hotelContext = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ClientAddVM model = new ClientAddVM();
            model.countries = _hotelContext.Countries.ToList();
            model.cities = _hotelContext.Cities.Where(c => c.CountryId == model.countries.FirstOrDefault(x => x.Name == "BiH").CountryId).ToList();           

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ClientAddVM model)
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult GetData(string id)
        {
            int inta = int.Parse(id);
            ClientAddVM c = new ClientAddVM();
            c.cities = _hotelContext.Cities.Where(cr => cr.CountryId == inta).ToList();
            return PartialView("SelectItemView", c);

        }


    }
}