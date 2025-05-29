using rirais.Domain.Common;

namespace rirais.Application.User.Register.Exceptions;

public class DuplicateNationalCodeException() : AbstractException(message: "Duplicate National Code");