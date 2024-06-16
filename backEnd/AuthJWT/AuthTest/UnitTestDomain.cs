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
        int telefono = 712382911;
        int ci = 12904899;


        PersonaModel result = new PersonaModel(id, nombre, apellido, telefono, ci);
    }
    
    
}