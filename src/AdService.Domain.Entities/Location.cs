namespace AdService.Domain.Entities
{
	public class Location
	{
		public int Id { get; set; }

		public required string CountryName { get; set; }

		public required string RegionName { get; set; }

		public string? DistrictName { get; set; }

		public string? CityName { get; set; }

		public double? Lattitude { get; set; }

		public double? Longitude { get; set; }
	}
}
