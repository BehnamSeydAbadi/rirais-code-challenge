using rirais.Domain.Common;

namespace rirais.Application.User.Exceptions;

public class DuplicateNationalCodeException() : AbstractException(message: "Duplicate National Code");