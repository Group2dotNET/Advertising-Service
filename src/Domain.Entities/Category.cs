namespace Domain.Entities
{
	/// <summary>
	/// Категория
	/// </summary>
	public class Category
	{
		public int Id { get; set; }

		public required string Title { get; set; }

		public string? Description { get; set; }

		public int? ParentId { get; set; }

		// TODO: Добавить поля: набор фильтров для объявления и набор характеристик для объявления
	}
}
