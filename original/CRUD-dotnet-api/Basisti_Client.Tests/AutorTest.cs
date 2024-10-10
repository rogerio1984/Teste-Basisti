using Basisti_Client.Model;

namespace Basisti_Client.Tests;

public class AutorTest
{
 
  [Fact]
  public void ValidarCamposSemNome()
  {
    // Arrange
    Autor autor = new Autor { CodAu = 12, Nome = "" };

    Assert.NotEmpty(autor.Nome);
  }
  [Fact]
  public void ValidarCamposComNome()
  {
    // Arrange
    Autor autor = new Autor { CodAu = 12, Nome = "teste" };

    Assert.NotEmpty(autor.Nome);
  }

  [Fact]
  public void ValidarCamposSemCodAu()
  {
    // Arrange
    Autor autor = new Autor { CodAu = 0, Nome = "teste" };

    Assert.True(autor.CodAu > 0);
  }

  [Fact]
  public void ValidarCamposComCodAu()
  {
    // Arrange
    Autor autor = new Autor { CodAu = 12, Nome = "teste" };

    Assert.True(autor.CodAu > 0);
  }
}
