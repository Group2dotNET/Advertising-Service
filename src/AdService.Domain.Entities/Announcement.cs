namespace AdService.Domain.Entities
{
	/// <summary>
	/// Объявление
	/// </summary>
	public class Announcement
	{
		public int Id { get; set; }

		/// <summary>
		/// Заголовок
		/// </summary>
		public required string Title { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Дата создания
		/// </summary>
		public DateTimeOffset CreateDate { get; set; }

		/// <summary>
		/// Дата обновления
		/// </summary>
		public DateTimeOffset? UpdateDate { get; set; }

		/// <summary>
		/// Категория
		/// </summary>
		public required Category Category { get; set; }

		public required int CategoryId { get; set; }

		/// <summary>
		/// Владелец
		/// </summary>
		public required User Owner { get; set; }

		public required int OwnerId { get; set; }
	}
}
