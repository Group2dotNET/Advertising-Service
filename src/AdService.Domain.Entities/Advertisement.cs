namespace AdService.Domain.Entities
{
	/// <summary>
	/// Объявление
	/// </summary>
	public class Advertisement
	{
		public int Id { get; set; }

		public required string Title { get; set; }

		public string? Description { get; set; }

		public DateTimeOffset CreateDate { get; set; }

		public DateTimeOffset? UpdateDate { get; set; }

		public required Category Category { get; set; }

		public List<Characteristic>? Characteristics { get; set; }

		public required User Owner { get; set; }

		public Location? Location { get; set; }
	}
}
