namespace AdService.Domain.Entities
{
	public class User
	{
		public int Id { get; set; }

		public required string Login { get; set; }

		public required string FirstName { get; set; }

		public required string LastName { get; set; }

		public string? MiddleName { get; set; }

		public required UserContactsInfo Contacts { get; set; }

		public int ExternalId { get; set; }
	}
}
