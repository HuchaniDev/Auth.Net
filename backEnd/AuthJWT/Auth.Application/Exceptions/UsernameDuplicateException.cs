using Auth.Application.Common;

namespace Auth.Application.Exceptions;

public class UsernameDuplicateException:AppLayerException
{
    public UsernameDuplicateException(string? username) : base($"el nombre de usuario {username}, ya existe")
    {
        
    }
}