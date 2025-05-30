using rirais.Domain.Common;

namespace rirais.Domain.User.Exceptions;

public class UnregisteredUserException() : AbstractException(message: "Unregistered User");