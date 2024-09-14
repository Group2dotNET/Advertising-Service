namespace Domain.Entities
{
	public class FilterInfo
	{
		public int Id { get; set; }

		public required string Title { get; set; }

		public string? Description { get; set; }

		public int CategoryId { get; set; }

		// ?
	}
}
