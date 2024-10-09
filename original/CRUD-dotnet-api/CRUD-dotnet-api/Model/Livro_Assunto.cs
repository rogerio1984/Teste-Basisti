using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basisti_Client.Model
{
  /// <summary>
  /// Entidade responsável por representar os livros vinculados a assuntos
  /// </summary>
  [Table("Livro_Assunto")]
  public class Livro_Assunto
  {
    [Key]
    [Required]
    public int Codl { get; set; }

    [Key] [Required]
    public int CodAs { get; set; }
    
    public Livro_Assunto()
    {
     
    }

  }
}
