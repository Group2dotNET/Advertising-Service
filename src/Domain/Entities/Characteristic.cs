namespace Domain.Entities
{
	public class Characteristic
	{
		public int Id { get; set; }

		public required string Name { get; set; }

		public string? Value { get; set; }

		public int? CategoryId { get; set; }
	}
}
