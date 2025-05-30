using rirais.Application.UnitOfWork;
using rirais.Application.User.Dto;
using rirais.Application.User.Exceptions;
using rirais.Domain.User.Specifications;

namespace rirais.Application.User.UpdateUserDetails;

internal class UpdateUserDetailsApplicationService(IUnitOfWork unitOfWork) : IUpdateUserDetailsApplicationService
{
    public async Task HandleAsync(Guid id, UserDto dto)
    {
        var anyDuplicateNationalCode = await unitOfWork.UserRepository.AnyAsync(
            new UserByNationalCodeSpecification(dto.NationalCode)
        );
        if (anyDuplicateNationalCode) throw new DuplicateNationalCodeException();

        var user = await unitOfWork.UserRepository.GetAsync(id, allowTracking: true);

        if (user is null) throw new UserNotFoundException();

        user.UpdateUserDetails(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);

        unitOfWork.UserRepository.Update(user);

        await unitOfWork.SaveChangesAsync();
    }
}