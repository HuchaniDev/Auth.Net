using Auth.Application.Common;

namespace Auth.Application.Exceptions;

public class PasswordIncorrectException:AppLayerException
{
    public PasswordIncorrectException(string? message) : base("Su contrasenia no coincide"){}
}