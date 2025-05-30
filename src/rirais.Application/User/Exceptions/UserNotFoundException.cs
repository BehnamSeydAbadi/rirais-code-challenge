using rirais.Domain.Common;

namespace rirais.Application.User.Exceptions;

public class UserNotFoundException() : AbstractException(message: "User not found");