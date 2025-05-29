namespace rirais.Application.User.ViewModels;

public record UserViewModel
{
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string DateOfBirth { get; set; }
}