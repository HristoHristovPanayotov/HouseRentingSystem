using HouseRentingSystem.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data.Configuration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agents>
    {
        public void Configure(EntityTypeBuilder<Agents> builder)
        {
            
            builder.HasData(SeedAgents());
        }

        private IEnumerable<Agents> SeedAgents()
        {
            return new Agents[]
            {
                new Agents
                {
                    Id = 1,
                    PhoneNumber = "0885197043",
                    UserId = "1"
                },

                new Agents
                {
                    Id = 1,
                    PhoneNumber = "0885197043",
                    UserId = "1"
                }
            };
        }   
    }
}
