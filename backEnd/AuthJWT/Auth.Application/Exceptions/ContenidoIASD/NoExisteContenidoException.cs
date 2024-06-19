using Auth.Application.Common;

namespace Auth.Application.Exceptions.ContenidoIASD;

public class NoExisteContenidoException: AppLayerException
{
    public NoExisteContenidoException() : base("no existe el contenido o recurso")
    {
    }
}