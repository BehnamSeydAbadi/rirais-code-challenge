namespace rirais.Domain.Tests.Dto;

public record UserInfromationDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalCode { get; set; }
    public required DateOnly DateOfBirth { get; set; }
}