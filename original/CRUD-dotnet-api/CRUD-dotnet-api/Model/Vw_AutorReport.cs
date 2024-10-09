namespace Basisti_Client.Model
{
  /// <summary>
  /// View responsável por retornar dados que iremos agrupar no angular
  /// </summary>
  public class Vw_AutorReport
  {
    public string Autor { get; set; }

    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; }
    public string Assuntos { get; set; }
    public string Valores { get; set; }

    public Vw_AutorReport() {
      Autor = string.Empty;
      Titulo = string.Empty;
      Editora = string.Empty;
      AnoPublicacao = string.Empty;
      Assuntos = string.Empty;
      Valores = string.Empty;
    }
  }
}
