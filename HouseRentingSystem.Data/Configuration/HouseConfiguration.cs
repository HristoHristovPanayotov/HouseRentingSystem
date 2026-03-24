using HouseRentingSystem.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data.Configuration
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasOne(h => h.Category).WithMany(c => c.Houses).HasForeignKey(h => h.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(SeedHouses());
        }

        private IEnumerable<House> SeedHouses()
        {
            return new House[]
            {
                new House
                {
                    Id = 1,
                    Title = "Jeremiah",
                    Address = "Street 12",
                    Description = "Lovely home",
                    ImageUrl = "https://www.livehome3d.com/useful-articles/how-to-design-a-house",
                    PricePerMonth = 109.00M,
                    CategoryId = 2,
                    AgentId = 1
                   
                },

                new House
                {
                    Id = 2,
                    Title = "George house",
                    Address = "Street 13",
                    Description = "Great home",
                    ImageUrl = "https://www.dreamstime.com/photos-images/house-modern-wood.html",
                    PricePerMonth = 150.00M,
                    CategoryId = 1,
                    AgentId = 1

                }

            };
        }
    }
}
