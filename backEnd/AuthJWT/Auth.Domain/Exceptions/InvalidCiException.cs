using Auth.Domain.Common;

namespace Auth.Domain.Exceptions;

public class InvalidCiException : DomainException
{
    public InvalidCiException() :base("ci invalido(deber ser numeros de entre 7 u 8 caracteres)"){}
}