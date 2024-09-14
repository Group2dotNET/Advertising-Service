namespace Domain.Entities
{
	public class Advertisement
	{
		public int Id { get; set; }

		public required string Title { get; set; }

		public string? Description { get; set; }

		public DateTimeOffset CreateDate { get; set; }

		public DateTimeOffset? UpdateDate { get; set; }

		public required Category Category { get; set; }

		// характеристики для товара

		// изображения

		public string Owner { get; set; }

		// отзывы

		// местоположение
	}
}
