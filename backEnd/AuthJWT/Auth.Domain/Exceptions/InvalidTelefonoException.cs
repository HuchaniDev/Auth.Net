using Auth.Domain.Common;

namespace Auth.Domain.Exceptions;

public class InvalidTelefonoException: DomainException
{
    public InvalidTelefonoException(): base("telefono invalido(debe contener 8 caracteres)") {}  
}