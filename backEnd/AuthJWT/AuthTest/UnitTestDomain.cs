using Auth.Domain.Exceptions;
using Auth.Domain.Models;

namespace AuthTest;

[TestClass]
public class UnitTestDomain
{
    [TestMethod]
    public void createModelPersona()
    {
        Guid id = Guid.NewGuid();
        string nombre = "daniel";
        string apellido = "Huchani Huaranca";
        int telefono = 71238291;
        int ci = 12904899;


        PersonaModel result = new PersonaModel(id, nombre, apellido, telefono, ci);
        
        Assert.IsNotNull(result);
        Assert.AreEqual(id, result.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidTelefonoException))]
    [DataRow("-12382912")]
    [DataRow("aa1238287912")]
    [DataRow("sd82912j")]
    public void ValidateTelefonoExceptions(string Telefono)
    {
        Guid id = Guid.NewGuid();
        string nombre = "daniel";
        string apellido = "Huchani Huaranca";
        int telefono = int.Parse(Telefono);
        int ci = 12904899;
        
        PersonaModel result = new PersonaModel(id, nombre, apellido, telefono, ci);

    }

    
}