namespace AdService.Domain.Entities;

public abstract class Entity<T> where T : struct
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public T Id { get; set; }
}
