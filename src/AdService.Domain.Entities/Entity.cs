namespace AdService.Domain.Entities;

/// <summary>
/// Базовый тип для сущности
/// </summary>
public abstract class Entity
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public int Id { get; set; }
}
