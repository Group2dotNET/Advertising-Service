namespace AdvertisingService.Customers.Contracts
{
    public record UserInfoDto(string UserName, string LastName, string FirstName, string MiddleName, string PhoneNumber, DateTime? Birthday, string Bio, string Address);
}
