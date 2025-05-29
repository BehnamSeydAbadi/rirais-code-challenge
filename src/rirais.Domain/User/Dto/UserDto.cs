namespace rirais.Domain.User.Dto;

public record UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public DateOnly DateOfBirth { get; set; }
}