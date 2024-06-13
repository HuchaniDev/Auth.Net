using Auth.Application.Common;

namespace Auth.Application.Exceptions;

public class UserNoExistException:AppLayerException
{
    public UserNoExistException() : base("El usuario no existe ! (no puede iniciar session)")
    { 
    }
}