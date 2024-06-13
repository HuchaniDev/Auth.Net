using Auth.Application.Common;

namespace Auth.Application.Exceptions;

public class PasswordIncorrectException:AppLayerException
{
    public PasswordIncorrectException() : base("Su contrasenia no coincide"){}
}