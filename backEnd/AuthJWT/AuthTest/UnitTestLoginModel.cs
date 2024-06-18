using Auth.Domain.Models;

namespace AuthTest;

[TestClass]
public class UnitTestLoginModel
{
    [TestMethod]
    public void ValidCreateLoginModel()
    {
        string UserName = "shark3";
        string Clave = "danieL3";

        LoginModel result = new(UserName, Clave);
        Assert.IsNotNull(result);
        Assert.AreEqual(UserName, result.UserName);
    }

    [TestMethod]
    public void ValidCreateUsuario()
    {
        string Username = "shark";
        string Email = "shark@gmail.com";
        string Password = "Admin123";

        Guid id = new Guid();
        string nombre = "daniel";
        string apellido = "huchani huaranca";
        int telefono = 34872342;
        int ci = 12981002;
        PersonaModel Persona = new PersonaModel(id,nombre,apellido,telefono,ci);

        UsuarioModel result = new UsuarioModel(Persona, Username, Email, Password);
        Assert.IsNotNull(result);
        Assert.AreEqual(Username, result.Username);
    }
}