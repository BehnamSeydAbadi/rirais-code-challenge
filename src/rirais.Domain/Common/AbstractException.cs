namespace rirais.Domain.Common;

public abstract class AbstractException : Exception
{
    public AbstractException(string message) : base(message)
    {
    }

    public AbstractException()
    {
    }
}