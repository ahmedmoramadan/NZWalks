namespace NZWalks.API.Models.DTOs
{
    public class UpdateWalksDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public String? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
