using Auth.Domain.Common;

namespace Auth.Domain.Exceptions;

public class InvalidEmailException:DomainException
{
    public InvalidEmailException() : base("Email invalid(debe contener @)")
    {
    }
}