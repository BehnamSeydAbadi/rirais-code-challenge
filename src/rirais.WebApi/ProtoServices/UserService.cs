using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using rirais.Application.User.GetUser;
using rirais.Application.User.GetUsers;
using rirais.Application.User.Register;
using rirais.Application.User.Unregister;
using rirais.Application.User.UpdateUserDetails;
using rirais.WebApi.Extensions;
using rirais.WebApi.Protos;

namespace rirais.WebApi.ProtoServices;

public class UserService : rirais.WebApi.Protos.UserService.UserServiceBase
{
    private readonly IRegisterApplicationService _registerApplicationService;
    private readonly IGetUserApplicationService _getUserApplicationService;
    private readonly IGetUsersApplicationService _getUsersApplicationService;
    private readonly IUpdateUserDetailsApplicationService _updateUserDetailsApplicationService;
    private readonly IUnregisterUserApplicationService _unregisterUserApplicationService;

    public UserService(
        IRegisterApplicationService registerApplicationService,
        IGetUserApplicationService getUserApplicationService,
        IGetUsersApplicationService getUsersApplicationService,
        IUpdateUserDetailsApplicationService updateUserDetailsApplicationService,
        IUnregisterUserApplicationService unregisterUserApplicationService
    )
    {
        _registerApplicationService = registerApplicationService;
        _getUserApplicationService = getUserApplicationService;
        _getUsersApplicationService = getUsersApplicationService;
        _updateUserDetailsApplicationService = updateUserDetailsApplicationService;
        _unregisterUserApplicationService = unregisterUserApplicationService;
    }

    public override async Task<UserIdReply> RegisterUser(UserDto request, ServerCallContext context)
    {
        var userId = await _registerApplicationService.HandleAsync(
            new Application.User.Dto.UserDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                NationalCode = request.NationalCode,
                DateOfBirth = request.DateOfBirth.ToDateOnly()
            }
        );

        return new UserIdReply { Id = userId.ToString() };
    }

    public override async Task<UserViewModel> GetUser(UserIdRequest request, ServerCallContext context)
    {
        var viewModel = await _getUserApplicationService.HandleAsync(request.Id.ToGuid());

        if (viewModel is null) return null;

        return new UserViewModel
        {
            Id = viewModel.Id.ToString(),
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            NationalCode = viewModel.NationalCode,
            DateOfBirth = viewModel.DateOfBirth.ToDateOnly().ToTimestamp(),
        };
    }

    public override async Task<UserViewModels> GetAllUsers(Empty request, ServerCallContext context)
    {
        var viewModels = await _getUsersApplicationService.HandleAsync();

        var userViewModels = new UserViewModels();
        userViewModels.Users.AddRange(
            viewModels.Select(vm => new UserViewModel
            {
                Id = vm.Id.ToString(),
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                NationalCode = vm.NationalCode,
                DateOfBirth = vm.DateOfBirth.ToDateOnly().ToTimestamp(),
            })
        );

        return userViewModels;
    }

    public override async Task<Empty> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        var userDto = new Application.User.Dto.UserDto
        {
            FirstName = request.User.FirstName,
            LastName = request.User.LastName,
            NationalCode = request.User.NationalCode,
            DateOfBirth = request.User.DateOfBirth.ToDateOnly()
        };

        await _updateUserDetailsApplicationService.HandleAsync(request.Id.ToGuid(), userDto);
        return new Empty();
    }

    public override async Task<Empty> DeleteUser(UserIdRequest request, ServerCallContext context)
    {
        await _unregisterUserApplicationService.HandleAsync(request.Id.ToGuid());
        return new Empty();
    }
}