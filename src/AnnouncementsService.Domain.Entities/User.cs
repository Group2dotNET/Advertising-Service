namespace AnnouncementsService.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User : Entity<Guid>
{
	/// <summary>
	/// Имя пользователя на ресурсе
	/// </summary>
	public required string Login { get; set; }

	/// <summary>
	/// Контактная информация пользователя
	/// </summary>
	public List<UserContactInfo>? Contacts { get; set; }

	/// <summary>
	/// Внешний идентификатор пользователя
	/// </summary>
	public int ExternalId { get; set; }
}
