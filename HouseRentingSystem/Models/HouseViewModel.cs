namespace HouseRentingSystem.Models.Houses
{
    public class HouseViewModel
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Address { get; init; } = null!;
        public string ImageUrl { get; init; } = null!;
        public decimal PricePerMonth { get; init; }
        public bool IsRented { get; init; }
    }
}