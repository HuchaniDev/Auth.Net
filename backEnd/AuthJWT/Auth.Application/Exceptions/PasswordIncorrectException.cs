using Auth.Application.Common;

namespace Auth.Application.Exceptions;

public class PasswordIncorrectException:AppLayerException
{
    public PasswordIncorrectException() : base("Su contrasenia no coincide"){}
    
    public PasswordIncorrectException(string message) : base(message)
    {
    }

    public PasswordIncorrectException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
}