using rirais.Domain.Common;

namespace rirais.Domain.User.Exceptions;

public class InvalidFullNameException() : AbstractException(message: "Invalid Full Name");