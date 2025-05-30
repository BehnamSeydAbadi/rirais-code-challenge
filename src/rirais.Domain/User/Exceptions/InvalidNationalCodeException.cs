using rirais.Domain.Common;

namespace rirais.Domain.User.Exceptions;

public class InvalidNationalCodeException() : AbstractException(message: "Invalid National Code");