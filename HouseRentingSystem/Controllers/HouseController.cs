using HouseRentingSystem.Data;
using HouseRentingSystem.Models.Houses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem.Controllers
{
    public class HousesController : Controller
    {
        private readonly HouseRentingDbContext data;

        public HousesController(HouseRentingDbContext _data)
        {
            this.data = _data;
        }

        public IActionResult All()
        {
            var houses = this.data.Houses
                .Select(h => new HouseViewModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null
                })
                .ToList();

            return View(houses);
        }

        [Authorize]
        public IActionResult Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var houses = new List<HouseViewModel>();

            if (this.data.Agents.Any(a => a.UserId == userId))
            {
                var agentId = this.data.Agents
                    .First(a => a.UserId == userId).Id;

                houses = this.data.Houses
                    .Where(h => h.AgentId == agentId)
                    .Select(h => new HouseViewModel
                    {
                        Id = h.Id,
                        Title = h.Title,
                        Address = h.Address,
                        ImageUrl = h.ImageUrl,
                        PricePerMonth = h.PricePerMonth,
                        IsRented = h.RenterId != null
                    })
                    .ToList();
            }
            else
            {
                houses = this.data.Houses
                    .Where(h => h.RenterId == userId)
                    .Select(h => new HouseViewModel
                    {
                        Id = h.Id,
                        Title = h.Title,
                        Address = h.Address,
                        ImageUrl = h.ImageUrl,
                        PricePerMonth = h.PricePerMonth,
                        IsRented = h.RenterId != null
                    })
                    .ToList();
            }

            return View(houses);
        }

        public IActionResult Details(int id)
        {
            if (!this.data.Houses.Any(h => h.Id == id))
            {
                return BadRequest();
            }

            var house = this.data.Houses
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsViewModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                    Category = h.Category.Name,
                    Agent = new Models.Agents.AgentViewModel
                    {
                        PhoneNumber = h.Agent.PhoneNumber,
                        Email = h.Agent.User.Email
                    }
                })
                .First();

            return View(house);
        }
    }
}