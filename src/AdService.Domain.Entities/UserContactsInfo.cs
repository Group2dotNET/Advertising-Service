namespace AdService.Domain.Entities
{
	public class UserContactsInfo
	{
		public int Id { get; set; }

		public string? Email { get; set; }

		public string? PhoneNumber { get; set; }

		public Dictionary<string, string>? SocialMedias { get; set; }
	}
}
