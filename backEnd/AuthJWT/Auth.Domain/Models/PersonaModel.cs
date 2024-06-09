using System.Globalization;
using System.Text.RegularExpressions;
using Auth.Domain.Exceptions;

namespace Auth.Domain.Models;

public class PersonaModel
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public int Telefono { get; private set; }
    public int Ci { get; private set; }

    public PersonaModel(
        Guid id,
        string nombre,
        string apellido,
        int telefono,
        int ci)
    {
        Id = id;
        Nombre = ValidateName(nombre);
        Apellido = ValidateApellido(apellido);
        Telefono = ValidateTelefono(telefono);
        Ci = ValidateCi(ci);
    }
    
    //validaciones en static y private
    //actualizaciones en public sin static
    
    private static int ValidateTelefono(int telefono)
    {
        if (new Regex(@"^\d{8}$").Match($"{telefono}").Success) return telefono;
        throw new InvalidTelefonoException();
    }

    private static string ValidateName(string nombre)
    {
        if (new Regex(@"^[a-zA-Z]+$").Match(nombre).Success) return ConvertToTitleCase(nombre);
        throw new InvalidNombreException();
    }

    private static string ValidateApellido(string apellido)
    {
        if (new Regex(@"^[a-zA-Z]+\s[a-zA-Z]+$").Match(apellido).Success) return ConvertToTitleCase(apellido);
        throw new InvalidApellidoException();
    }

    private static int ValidateCi(int ci)
    {
        if (new Regex(@"^\d{7,8}$").Match($"{ci}").Success) return ci;
        throw new InvalidCiException();
    }
    
    private static string ConvertToTitleCase(string str)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }
}
