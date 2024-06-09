using Auth.Domain.Common;

namespace Auth.Domain.Exceptions;

public class InvalidPasswordException:DomainException
{
    public InvalidPasswordException():base("Pasword Invalid(debe contener minimo 4 caracteres y Mayusculas, miniscula,numeros)")
    {
        
    }
}