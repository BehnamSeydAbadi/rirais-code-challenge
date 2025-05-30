using rirais.Application.UnitOfWork;
using rirais.Application.User.Dto;
using rirais.Application.User.Register.Exceptions;
using rirais.Domain.User;
using rirais.Domain.User.Specifications;

namespace rirais.Application.User.Register;

internal class RegisterApplicationService(IUnitOfWork unitOfWork) : IRegisterApplicationService
{
    public async Task<Guid> HandleAsync(UserDto dto)
    {
        var anyDuplicateNationalCode = await unitOfWork.UserRepository.AnyAsync(
            new UserByNationalCodeSpecification(dto.NationalCode)
        );
        if (anyDuplicateNationalCode) throw new DuplicateNationalCodeException();


        var userEntity = UserEntity.Register(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);

        unitOfWork.UserRepository.Add(userEntity);

        await unitOfWork.SaveChangesAsync();

        return userEntity.Id;
    }
}