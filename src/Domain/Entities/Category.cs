namespace Domain.Entities
{
	public class Category
	{
		public int Id { get; set; }

		public required string Title { get; set; }

		public string? Description { get; set; }

		public int? ParentId { get; set; }

		// фильтры

		// характеристики для категории
	}
}
