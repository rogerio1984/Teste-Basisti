using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basisti_Client.Model
{
  /// <summary>
  /// Entidade responsável por representar os autores do banco de dados
  /// </summary>
  [Table("Autor")]
  public class Autor
  {
    /// <summary>
    /// Chave da tabela
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodAu { get; set; }
    /// <summary>
    /// Nome do autor
    /// </summary>    
    [Required]
    [StringLength(40)]
    public string Nome { get; set; }

    [JsonIgnore]
    /// <summary>
    /// Contem a lista de autores relacionado ao livro
    /// </summary>
    public ICollection<Livro_Autor> Livro_Autores { get; set; }

    /// <summary>
    /// Construtor padrão incializando as variáveis 
    /// </summary>
    public Autor() {
      Nome =  string.Empty;
      Livro_Autores = new List<Livro_Autor>();
    }

  }
}
