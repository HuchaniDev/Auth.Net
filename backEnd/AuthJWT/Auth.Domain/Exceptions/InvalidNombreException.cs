using Auth.Domain.Common;

namespace Auth.Domain.Exceptions;

public class InvalidNombreException: DomainException
{
    public InvalidNombreException():base("Nombre invalido(los Nombres no contienen numeros ni caracteres especiales)"){}
}