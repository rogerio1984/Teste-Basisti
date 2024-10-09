using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basisti_Client.Model
{
  /// <summary>
  /// Entidade responsável por representar os livros vinculados a autores
  /// </summary>
  [Table("Livro_Autor")]
  public class Livro_Autor
  {
    [Key] [Required]
    public int Codl { get; set; }
    

    [Key] [Required]
    public int CodAu { get; set; }
   

    public Livro_Autor()
    {
    }

  }
}
