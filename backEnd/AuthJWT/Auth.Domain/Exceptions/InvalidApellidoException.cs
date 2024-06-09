using Auth.Domain.Common;

namespace Auth.Domain.Exceptions;

public class InvalidApellidoException:DomainException
{
    public InvalidApellidoException():base("apellido invalido(solo texto y 2 apellidos)") {}
}