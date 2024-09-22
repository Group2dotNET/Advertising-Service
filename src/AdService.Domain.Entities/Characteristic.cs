namespace AdService.Domain.Entities
{
	public class Characteristic
	{
		public int Id { get; set; }
		
		public required string Name { get; set; }

		public string? Description { get; set; }

		public object? Value { get; set; }
	}
}
