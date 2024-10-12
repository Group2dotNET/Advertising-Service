namespace AdService.Domain.Entities;

/// <summary>
/// Контактная информация пользователя
/// </summary>
public class UserContactInfo : Entity
{
	/// <summary>
	/// Тип контактной информации
	/// </summary>
	public required string Type { get; set; }

	/// <summary>
	/// Контакт пользователя
	/// </summary>
	public string? Value { get; set; }

	/// <summary>
	/// Пользователь
	/// </summary>
	public required User User { get; set; }

	public required int UserId { get; set; }
}
