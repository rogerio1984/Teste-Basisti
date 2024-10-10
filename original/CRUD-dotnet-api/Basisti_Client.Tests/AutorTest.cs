using Basisti_Client.Model;

namespace Basisti_Client.Tests;

public class AutorTest
{
 
  [Fact]
  public void ValidarCamposSemNome()
  {
    Autor autor = new Autor { CodAu = 12, Nome = "" };

    Assert.NotEmpty(autor.Nome);
  }
  [Fact]
  public void ValidarCamposComNome()
  {
    Autor autor = new Autor { CodAu = 12, Nome = "teste" };

    Assert.NotEmpty(autor.Nome);
  }

  [Fact]
  public void ValidarCamposSemCodAu()
  {
    Autor autor = new Autor { CodAu = 0, Nome = "teste" };

    Assert.True(autor.CodAu > 0);
  }

  [Fact]
  public void ValidarCamposComCodAu()
  {
    Autor autor = new Autor { CodAu = 12, Nome = "teste" };

    Assert.True(autor.CodAu > 0);
  }
}
