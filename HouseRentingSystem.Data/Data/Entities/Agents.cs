using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static HouseRentingSystem.Data.DataConstants.Agent;

namespace HouseRentingSystem.Data.Entities
{
    public class Agent
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; init; } = null!;
    }
}