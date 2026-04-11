using System.Diagnostics;
using HouseRentingSystem.Data;
using HouseRentingSystem.Models;
using HouseRentingSystem.Models.Home;
using HouseRentingSystem.Data.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly HouseRentingDbContext data;

        public HomeController(HouseRentingDbContext _data)
        {
            this.data = _data;
        }

        public IActionResult Index()
        {
            var totalHouses = this.data.Houses.Count();
            var totalRents = this.data.Houses.Count(h => h.RenterId != null);

            var houses = this.data.Houses
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseIndexViewModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .Take(3)
                .ToList();

            var model = new IndexViewModel
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents,
                Houses = houses
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}