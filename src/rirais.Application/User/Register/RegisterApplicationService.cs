using rirais.Application.UnitOfWork;
using rirais.Application.User.Register.Exceptions;
using rirais.Domain.User;
using rirais.Domain.User.Dto;
using rirais.Domain.User.Specifications;

namespace rirais.Application.User.Register;

internal class RegisterApplicationService : IRegisterApplicationService
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterApplicationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> HandleAsync(UserDto dto)
    {
        var anyDuplicateNationalCode = await _unitOfWork.UserRepository.AnyAsync(
            new UserByNationalCodeSpecification(dto.NationalCode)
        );
        if (anyDuplicateNationalCode) throw new DuplicateNationalCodeException();


        var userEntity = UserEntity.Register(dto);

        _unitOfWork.UserRepository.Add(userEntity);

        await _unitOfWork.SaveChangesAsync();

        return userEntity.Id;
    }
}