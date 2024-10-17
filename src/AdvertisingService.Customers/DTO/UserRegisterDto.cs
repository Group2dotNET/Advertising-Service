namespace AdvertisingService.Customers.DTO
{
    public record UserRegisterDto(string FirstName, string LastName, string? MiddleName, string Email, string Password, string ConfirmPassword);
}
